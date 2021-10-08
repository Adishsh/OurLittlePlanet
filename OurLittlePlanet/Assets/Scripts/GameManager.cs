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

    private UnityAction<Slot> SelectCardListener;
    private UnityAction<Slot> BuyCardListener;
    private UnityAction DrawCardsListener;
    private UnityAction EndTurnListener;
    private UnityAction<int> BuildListener;

    private void Awake() 
    {
        SetListeners();
        SetGameState(GameState.StartTurn);
    }

    private void SetGameState(GameState newState)
    {
        m_Board.SetDrwaingSelectable(newState == GameState.Drawing);
        m_Board.SetPlayingSelectable(newState == GameState.PlayingCards);
        gameState = newState;

        if(newState == GameState.StartTurn)
        {
            StartTurn();
        }

        if(newState == GameState.LoseGame)
        {
            LoseGame();
        }
    }

    private void SetListeners()
    {
        SelectCardListener = new UnityAction<Slot> (SelectHandSlot);
        BuyCardListener = new UnityAction<Slot>(BuyCard);
        DrawCardsListener = new UnityAction(DrawCardsToHand);
        EndTurnListener = new UnityAction(EndTurn);
        BuildListener = new UnityAction<int>(BuildCard);

        EventManager.instance.SelectCard.AddListener(SelectCardListener);
        EventManager.instance.BuyCard.AddListener(BuyCardListener);
        EventManager.instance.DrawCards.AddListener(DrawCardsListener);
        EventManager.instance.EndTurn.AddListener(EndTurnListener);
        EventManager.instance.BuildCard.AddListener(BuildListener);
    
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
            Debug.LogError($"error buy card {card}");
            return;
        }
        int cost = card.m_CardData.m_Cost;
        if (m_StatsManager.m_Money > cost)
        {
            m_StatsManager.AddMoney(-cost);
            m_Board.BuyCard(slot);
        }
    }

    private void SelectHandSlot(Slot slot)
    {
        Card card =slot.card;
        if(!card)
        {
            Debug.LogError($"error select card {card}");
            return;
        }
        if(gameState != GameState.PlayingCards)
        {
            Debug.LogError($"hand is selectable not in playing mode");
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
        if(selectedSlot != null)
        {
            m_Board.BuildCard(selectedSlot, selectedBuildingSlot);
            UnSelectSlot();
        }
    }

    private void DrawCardsToHand()
    {
        if(gameState != GameState.Drawing)
        {
            Debug.LogError("not in drawing mode");
            return;
        }
        Debug.Log($"m_StatsManager.m_CardsToDraw:{m_StatsManager.m_CardsToDraw}");
        m_Board.DrawCardToHand(m_StatsManager.m_CardsToDraw);

        SetGameState(GameState.PlayingCards);

    }

    private void EndTurn()
    {
        if(gameState != GameState.PlayingCards)
        {
            Debug.LogError("not in playing mode");
            return;
        }
        m_Board.DiscardHand();
        EndTurnCalculation();
        AddEventCardToEventDeck();
        UnSelectSlot();
        if (m_StatsManager.DidStrikeOut())
        {
            Debug.LogError("LoseGame");
            SetGameState(GameState.LoseGame);
        }
        SetGameState(GameState.StartTurn);
    }
    
    private void AddEventCardToEventDeck()
    {
       int newEventsAmount = m_StatsManager.GetEventCardsAmountToDraw();
        Debug.Log("AddEventCardToEventDeck: "+newEventsAmount);

       m_Board.AddEventCardToEventDeck(newEventsAmount);

    }

    private void LoseGame()
    {
        Debug.Log("you lose");
    }

    private void EndTurnCalculation()
    {
        m_Board.EndTurnImpactCalculations.Invoke(m_StatsManager);
        if(m_StatsManager.m_Resources > m_ResourcesList[resourceIndex])
        {
            resourceIndex++;
        } 
        else
        {
            m_StatsManager.AddStrikes();
        }
    }

    private void ActivateEvents()
    {
        m_Board.SetNextEvent.Invoke(m_StatsManager);
        SetGameState(GameState.Drawing);
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
