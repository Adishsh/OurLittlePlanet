using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    private Slot selectedSlot;
    private GameState gameState;
    
   [SerializeField] StatsManager m_StatsManager;
   [SerializeField] private Board m_Board;
   [SerializeField] List<int> m_ResourcesList;
   [SerializeField] int m_NumberOfDaysToChangeEra;
    [SerializeField] GameObject LoseText;    
    [SerializeField] GameObject WinText;
   [SerializeField] private TutorialAnimator m_Tutorial;
   [SerializeField] private TutorialAnimator m_NewEra;


   private int day;
   private int resourceIndex;
   private int currentEra;


    enum GameState
    {
        StartTurn,
        Drawing,
        PlayingCards,
        EndOfTurn,
        LoseGame,
    }
    private UnityAction<Slot> SelectDiscardCardListener;
    private UnityAction<Slot> SelectCardListener;
    private UnityAction<Slot> BuyCardListener;
    private UnityAction DrawCardsListener;
    private UnityAction EndTurnListener;
    private UnityAction WinGameListener;
    private UnityAction<int> BuildListener;
    [SerializeField] private AudioManager audiomanager;
    
    private void Awake() 
    {
        SetListeners();
    }

    private void Start() 
    {
        StartCoroutine(WaitAndStart());
//        audiomanager.Play_Sound(AudioManager.SoundTypes.Music_Background);
//        audiomanager.Play_Sound(AudioManager.SoundTypes.GamePlay);
 //       audiomanager.Play_Sound(AudioManager.SoundTypes.Atmosphere);
    }

    IEnumerator WaitAndStart()
    {
        yield return null;
        SetGameState(GameState.StartTurn);
    //    m_Tutorial.StartAnimation();
    }


    private void SetGameState(GameState newState)
    {
        m_Board.SetDrwaingSelectable(newState == GameState.Drawing);
        m_Board.SetPlayingSelectable(newState == GameState.PlayingCards);
        gameState = newState;

        if(newState == GameState.StartTurn)
        {
            StartTurn();
            return;
        }

        if(newState == GameState.LoseGame)
        {
            LoseGame();
             m_Board.SetDrwaingSelectable(false);
        m_Board.SetPlayingSelectable(false);
            return;
        }

        if(newState == GameState.Drawing)
        {
             EventManager.instance.DrawCards.Invoke();
            return;
        }
    }

    private void SetListeners()
    {
        SelectDiscardCardListener = new UnityAction<Slot> (SellCard);
        SelectCardListener = new UnityAction<Slot> (SelectHandSlot);
        BuyCardListener = new UnityAction<Slot>(BuyCard);
        DrawCardsListener = new UnityAction(DrawCardsToHand);
        EndTurnListener = new UnityAction(EndTurn);
        BuildListener = new UnityAction<int>(BuildCard);
        WinGameListener = new UnityAction(WinGame);

        EventManager.instance.SelectDiscardCard.AddListener(SelectDiscardCardListener);
        EventManager.instance.SelectCard.AddListener(SelectCardListener);
        EventManager.instance.BuyCard.AddListener(BuyCardListener);
        EventManager.instance.DrawCards.AddListener(DrawCardsListener);
        EventManager.instance.EndTurn.AddListener(EndTurnListener);
        EventManager.instance.BuildCard.AddListener(BuildListener);
        EventManager.instance.WinGame.AddListener(WinGameListener);
    }

    private void StartTurn()
    {
        day++;
        m_StatsManager.SetDay(day);

        int era =day / m_NumberOfDaysToChangeEra;
        if(era > currentEra)
        {
            currentEra = era;
            m_StatsManager.SetEra(era);
            m_Board.ChangeEra(era);
            m_NewEra.StartAnimation();
        }
        SetRecourcesGoal();
        ActivateEvents();
        SetGameState(GameState.Drawing);
    }

    private void SetRecourcesGoal()
    {
        m_StatsManager.SetResourcesGoal(m_ResourcesList[resourceIndex]);
    }
 
    private void BuyCard(Slot slot)
    {
        Card card = slot.card;
        if(!card)
        {
            Debug.Log($"error buy card {card}");
            return;
        }
        int cost = card.m_CardData.m_Cost;
        if (m_StatsManager.m_Money >= cost)
        {
            m_StatsManager.AddMoney(-cost);
            m_Board.BuyCard(slot);
        }else
        {
            Debug.Log($"no money to buy card {card} money:{m_StatsManager.m_Money} cost:{card.m_CardData.m_Cost}");

        }
    }

    private void SellCard(Slot slot)
    {
        if(m_StatsManager.freeDiscardCardCount > 0)
        {
            m_StatsManager.freeDiscardCardCount--;
        }
        else
        {
            int cost = StatsManager.Instance.m_Era*10 +10;
            if (m_StatsManager.m_Money < cost)
            {
                return;
            }
            m_StatsManager.AddMoney(-cost);
        }
        m_Board.SellCard(slot);
    }

    private void SelectHandSlot(Slot slot)
    {
        Card card =slot.card;
        if(!card)
        {
            Debug.Log($"error select card {card}");
            return;
        }
        if(gameState != GameState.PlayingCards)
        {
            Debug.Log($"hand is selectable not in playing mode");
            return;
        }
        
        if(selectedSlot != null)
        {
            selectedSlot.SelectSlot(false);
        }
        selectedSlot = slot;
        selectedSlot.SelectSlot(true);
        m_Board.SetBuildSelectable(true);
    }

    private void UnSelectSlot()
    {
        if(selectedSlot)
        {
            selectedSlot.SelectSlot(false);
            m_Board.SetBuildSelectable(false);
            selectedSlot = null;
        }
    }

    private void BuildCard(int selectedBuildingSlot)
    {
            Debug.Log("BuildCard 1");
        if(selectedSlot != null)
        {
            Debug.Log("BuildCard 2");

            m_Board.BuildCard(selectedSlot, selectedBuildingSlot);
            UnSelectSlot();
        }
    }

    private void DrawCardsToHand()
    {
        if(gameState != GameState.Drawing)
        {
            Debug.Log("not in drawing mode");
            return;
        }
        m_Board.DrawCardToHand(m_StatsManager.m_CardsToDraw);

        SetGameState(GameState.PlayingCards);
    }

    private void EndTurn()
    {
        if(gameState != GameState.PlayingCards)
        {
            Debug.Log("not in playing mode");
            return;
        }
        //go to animator and stop its animation
        m_StatsManager.m_CurrentEvent.StopCurrentAnimation();
        m_Board.DiscardHand();
        EndTurnCalculation();
        AddEventCardToEventDeck();
        UnSelectSlot();
        if (m_StatsManager.DidStrikeOut())
        {
            Debug.Log("LoseGame");
            Time.timeScale = 0;
            SetGameState(GameState.LoseGame);
        }
        SetGameState(GameState.StartTurn);
    }
    
    private void AddEventCardToEventDeck()
    {
       int newEventsAmount = m_StatsManager.GetEventCardsAmountToDraw();
        Debug.Log("AddEventCardToEventDeck: "+newEventsAmount);

       m_Board.AddEventCardToEventDeck(newEventsAmount);
       if(newEventsAmount>0)
       {
           m_StatsManager.BadEventAdded();
       }

    }

    private void LoseGame()
    {
        LoseText.SetActive(true);
    }

        private void WinGame()
    {
       WinText.SetActive(true);

    }

    private void EndTurnCalculation()
    {
        m_Board.EndTurnImpactCalculations.Invoke(m_StatsManager);
        if(m_StatsManager.m_Resources >= m_ResourcesList[resourceIndex] + m_StatsManager.m_ExtraNeededResources)
        {
            resourceIndex++;
        } 
        else
        {
            m_StatsManager.AddLife(-1);
        }
    }

    private void ActivateEvents()
    {
        m_Board.SetNextEvent.Invoke(m_StatsManager);
    }

    private void OnDestroy() 
    {
        EventManager.instance.SelectCard.RemoveAllListeners();
        EventManager.instance.BuyCard.RemoveAllListeners();
        EventManager.instance.DrawCards.RemoveAllListeners();
        EventManager.instance.EndTurn.RemoveAllListeners();
        EventManager.instance.BuildCard.RemoveAllListeners();
    }

}
