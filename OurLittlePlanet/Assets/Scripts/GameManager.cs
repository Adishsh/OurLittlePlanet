using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private Card selectedCard;
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
        gameState = GameState.Drawing;
        SetUpGame();
    }

    private void SetListeners()
    {
        SelectCardListener = new UnityAction<Slot> (SelectCard);
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
        if(!slot.card)
        {
            Debug.LogError($"error select card {slot.card}");
            return;
        }
        Money = Money - slot.card.m_CardData.m_Cost;
        display.SetMoney(Money);
        Board.BuyCard(slot.card);
    }

    private void SelectCard(Slot slot)
    {
        if(!slot.card)
        {
            Debug.LogError($"error select card {slot.card}");
            return;
        }
        if(gameState != GameState.PlayingCards)
        {
            return;
        }
        
        if(selectedCard != null)
        {
            selectedCard.UnselectCard();
        }
        selectedCard = slot.card;
        selectedCard?.SelectCard();
    }

    private void UnSelectCard()
    {
        if(selectedCard)
        {
            selectedCard.UnselectCard();
            selectedCard = null;
        }
    }

    private void BuildCard(int selectedBuildingSlot)
    {
        if(selectedCard != null)
        {
            Board.BuildCard(selectedCard, selectedBuildingSlot);
            UnSelectCard();
        }
    }

    private void DrawCardsToHand()
    {
        if(gameState == GameState.Drawing)
        {
            Board.DrawCardToHand(3);
        }
        gameState = GameState.PlayingCards;
    }

    private void EndTurn()
    {
        if(gameState == GameState.PlayingCards)
        {
            Debug.Log("end turn pressed");
            Board.DiscardHand();
            EndTurnCalculation();
            UnSelectCard();
            ActivateEvents();
            gameState = GameState.Drawing;
        }
    }

    private void EndTurnCalculation()
    {
        Polution = Board.GetEndTurnPolution();
        display.SetPolution(Polution);
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
