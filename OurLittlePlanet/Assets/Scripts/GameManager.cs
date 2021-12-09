using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Slot selectedSlot;
    private GameState gameState;
    
   [SerializeField] StatsManager m_StatsManager;
   [SerializeField] private Board m_Board;
   [SerializeField] List<int> m_ResourcesList;
   [SerializeField] int m_NumberOfDaysToChangeEra;
    [SerializeField] GameObject LoseText;    
    [SerializeField] TMP_Text LoseDayNum;    
    [SerializeField] GameObject WinText;
   [SerializeField] private TutorialShowInOrder m_Tutorial;
   [SerializeField] private TutorialAnimator m_NewEra;
    [SerializeField] Menu m_Menu;    


   private int day;
   private int resourceIndex;
   private int currentEra;
    private bool winGame;

    enum GameState
    {
        Beginning,
        StartTurn,
        Drawing,
        EraChange,
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
        audiomanager.Play_Sound(AudioManager.SoundTypes.Music_Background);
        m_Menu.ShowMenu(false);
    }
    
    public void StartGame() 
    {
        m_Menu.HideMenu();
        SetGameState(GameState.StartTurn);
        audiomanager.Play_Sound(AudioManager.SoundTypes.Music_Background2);
        audiomanager.Play_Sound(AudioManager.SoundTypes.Atmosphere);
        audiomanager.Play_Sound(AudioManager.SoundTypes.Atmosphere2);
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void StartTutorial() 
    {
        if(gameState == GameState.Beginning)
        {
            StartGame();
        }
        m_Menu.HideMenu();
        m_Tutorial.StartTutorial();
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
        bool eraChange = era > currentEra;
        SetRecourcesGoal();
        if(eraChange)
        {
            currentEra = era;
            m_StatsManager.SetEra(era);
            m_Board.ChangeEra(era);
            m_NewEra.StartAnimation(StartEventAfterEraEnd);
            Debug.Log($"Ron- new era");
            SetGameState(GameState.EraChange);
        }else
        {
            StartEventAfterEraEnd();
        }
    }

    public void StartEventAfterEraEnd()
    {
        ActivateEvents();
        SetGameState( GameState.Drawing);
    }

    private IEnumerator StartStateAfterDelay(float seconds, GameState state)
    {
        yield return new WaitForSeconds(seconds);
        SetGameState(state);
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
            Debug.Log($"Ron- Buy Card from market");
            AudioManager.S.Play_Sound((AudioManager.SoundTypes.Buycard));
        }else
        {
            AudioManager.S.Play_Sound((AudioManager.SoundTypes.FailiBuycard));
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
                AudioManager.S.Play_Sound((AudioManager.SoundTypes.FailiBuycard));
                return;
            }
            m_StatsManager.AddMoney(-cost);
            AudioManager.S.Play_Sound((AudioManager.SoundTypes.Buycard));
        }
        Debug.Log($"Ron- Sell Card from discard");
        m_Board.SellCard(slot);
    }

    private void SelectHandSlot(Slot slot)
    {
        Debug.Log($"SelectHandSlot {slot}");
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
        bool wasSelected = selectedSlot == slot;
        if(selectedSlot != null)
        {
            UnSelectSlot();

        }
        selectedSlot = slot;
        selectedSlot.SelectSlot(true);
        selectedSlot.card?.ShowTooltip();
        if(m_Board.IsHandSlot(selectedSlot))
        {
            if(!wasSelected)
            {
                m_Board.SetBuildSelectable(true);
            }
            else
            {
                if(!StatsManager.Instance.CardIsDragged)
                {
                    UnSelectSlot();
                }
            }
        }
        else
        {
            if(wasSelected)
            {
                EventManager.instance.BuyCard.Invoke(slot);
                UnSelectSlot();
            }
        }
        Debug.Log($"Ron- hand cardSelected");

    }

    private void UnSelectSlot()
    {
        if(selectedSlot)
        {
            selectedSlot.card?.HideTooltip();
            selectedSlot.SelectSlot(false);
            m_Board.SetBuildSelectable(false);
            selectedSlot = null;
        }
    }

    private void BuildCard(int selectedBuildingSlot)
    {
            Debug.Log("BuildCard 1");
        if(selectedSlot != null && m_Board.IsHandSlot(selectedSlot) )
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
        m_StatsManager?.m_CurrentEvent?.StopCurrentAnimation();
        UnSelectSlot();
        m_Board.DiscardHand();
        EndTurnCalculation();

        if (m_StatsManager.DidStrikeOut())
        {
            Debug.Log("LoseGame");
            Time.timeScale = 0;
            SetGameState(GameState.LoseGame);
            return;
        }
        bool addedEvent = AddEventCardToEventDeck();
        float timeToWait = addedEvent ? 4f: 1f;
        SetGameState(GameState.EndOfTurn);
        StartCoroutine(StartStateAfterDelay(timeToWait, GameState.StartTurn));
    }
    
    private bool AddEventCardToEventDeck()
    {
       int newEventsAmount = m_StatsManager.GetEventCardsAmountToDraw();
        Debug.Log("AddEventCardToEventDeck: "+newEventsAmount);

       m_Board.AddEventCardToEventDeck(newEventsAmount);
        return newEventsAmount >0;
    }

    private void LoseGame()
    {
        if(!winGame)
        {
            AudioManager.S.Play_Sound((AudioManager.SoundTypes.Lose));
            AudioManager.S.Play_Sound((AudioManager.SoundTypes.Lose2));
            LoseText.SetActive(true);
            LoseDayNum.text = day.ToString();
        }
    }

    private void WinGame()
    {
        if(gameState != GameState.LoseGame)
        {
            AudioManager.S.Play_Sound((AudioManager.SoundTypes.Win));
            WinText.SetActive(true);
            winGame =true;        
        }
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

    private float ActivateEvents()
    {
        return m_Board.SetAndActivateNextEvent(m_StatsManager);
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
