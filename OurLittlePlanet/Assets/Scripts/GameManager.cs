using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private Slot selectedSlot;
    private GameState gameState;

   [SerializeField] int Money = 1000;
   [SerializeField] int Population = 1000;   
   [SerializeField] int Polution = 0;
   [SerializeField] StatsDisplay display;
   [SerializeField] private Board Board;

    enum GameState
    {
        Drawing,
        Events,
        PlayingCards,
        EndOfTurn,
    }
    private UnityAction<Slot> SelectCardListener;
    private UnityAction<Slot> BuyCardListener;
    private UnityAction DrawCardsListener;
    private UnityAction EndTurnListener;
    private UnityAction<int> BuildListener;

    private void Awake() 
    {
        SetListeners();
        SetGameState(GameState.Drawing);
        SetUpGame();
    }

    private void SetGameState(GameState newState)
    {
        Board.SetDrwaingSelectable(newState == GameState.Drawing);
        Board.SetPlayingSelectable(newState == GameState.PlayingCards);
        gameState = newState;
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

    private void BuyCard(Slot slot)
    {
        Card card = slot.card;
        if(!card)
        {
            Debug.LogError($"error buy card {card}");
            return;
        }
        int cost = card.m_CardData.m_Cost;
        if (Money > cost)
        {
            Money = Money - cost;
            display.SetMoney(Money);
            Board.BuyCard(slot);
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
        Board.SetBuildSelectable(true);
    }

    private void UnSelectSlot()
    {
        if(selectedSlot)
        {
            selectedSlot.SelectSlot(false);
            Board.SetBuildSelectable(false);
            selectedSlot = null;
        }
    }

    private void BuildCard(int selectedBuildingSlot)
    {
        if(selectedSlot != null)
        {
            Board.BuildCard(selectedSlot, selectedBuildingSlot);
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
        SetGameState(GameState.PlayingCards);
        Board.DrawCardToHand(3);
    }

    private void EndTurn()
    {
        if(gameState != GameState.PlayingCards)
        {
            Debug.LogError("not in playing mode");
            return;
        }
        Board.DiscardHand();
        EndTurnCalculation();
        UnSelectSlot();
        ActivateEvents();
        SetGameState(GameState.Drawing);
    }

    private void EndTurnCalculation()
    {
        CardImpact impact= Board.GetEndTurnImpact();
        Polution = impact.polution;
        Population = impact.population;
        display.SetPolution(Polution);
        display.SetPopulation(Population);
    }
    
    private void SetUpGame()
    {
        display.SetMoney(Money);
        display.SetPolution(Polution);
    }
    
    private void ActivateEvents()
    {

    }

    private void OnDestroy() {
        EventManager.instance.SelectCard.RemoveAllListeners();
        EventManager.instance.BuyCard.RemoveAllListeners();
        EventManager.instance.DrawCards.RemoveAllListeners();
        EventManager.instance.EndTurn.RemoveAllListeners();
        EventManager.instance.BuildCard.RemoveAllListeners();
    }

}
