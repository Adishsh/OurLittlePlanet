using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private Board Board;
    private Card selectedCard;
    private GameState gameState;

   [SerializeField] CardsCollection EventDeck;
   [SerializeField] Deck Deck;
   [SerializeField] Hand Hand;
   [SerializeField] Discard Discard;
   [SerializeField] CardsCollection Market;
   [SerializeField] WorldMap Map;
   [SerializeField] int Money = 1000;
   [SerializeField] int Population = 1000;   
   [SerializeField] int Polution = 0;
   [SerializeField] StatsDisplay display;
    enum GameState
    {
        Drawing,
        Events,
        PlayingCards,
        EndOfTurn,
    }
    private UnityAction<Card> SelectCardListener;
    private UnityAction<Card> BuyCardListener;
    private UnityAction DrawCardsListener;
    private UnityAction EndTurnListener;
    private UnityAction<int> BuildListener;

    private void Awake() 
    {
        Board = new Board(EventDeck, Deck, Hand, Discard, Market, Map);
        SetListeners();
        gameState = GameState.Drawing;
        SetUpGame();
    }

    private void SetListeners()
    {
        SelectCardListener = new UnityAction<Card> (SelectCard);
        BuyCardListener = new UnityAction<Card>(BuyCard);
        DrawCardsListener = new UnityAction(DrawCardsToHand);
        EndTurnListener = new UnityAction(EndTurn);
        BuildListener = new UnityAction<int>(BuildCard);

        EventManager.instance.SelectCard.AddListener(SelectCardListener);
        EventManager.instance.BuyCard.AddListener(BuyCardListener);
        EventManager.instance.DrawCards.AddListener(DrawCardsListener);
        EventManager.instance.EndTurn.AddListener(EndTurnListener);
        EventManager.instance.BuildCard.AddListener(BuildListener);
    
    }

    private void BuyCard(Card card)
    {
        Money = Money - card.m_CardData.m_Cost;
        display.SetMoney(Money);
        Board.BuyCard(card);
    }

    private void SelectCard(Card card)
    {
        if(gameState != GameState.PlayingCards)
        {
            return;
        }
        
        if(selectedCard != null)
        {
            selectedCard.UnselectCard();
        }
        selectedCard = card;
    }

    private void BuildCard(int selectedBuildingSlot)
    {
        Debug.Log($" bc1: {selectedCard} +{selectedBuildingSlot}");

        if(selectedCard != null)
        {
            Board.BuildCard(selectedCard, selectedBuildingSlot);
            SelectCard(null);
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
            SelectCard(null);
            ActivateEvent();
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
    
    private void ActivateEvent()
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
