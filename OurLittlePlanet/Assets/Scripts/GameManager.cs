using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Board Board;
    public Card selectedCard;
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

    private void Awake() 
    {
        Board = new Board(EventDeck, Deck, Hand, Discard, Market, Map);
        Instance = this;
        gameState = GameState.Drawing;
        display.SetMoney(Money);
        display.SetPolution(Polution);


    }
        
    private void SetUpGame()
    {

    }
    
    private void ActivateEvent()
    {

    }

    public void BuyCard(Card card)
    {
        Money = Money - card.m_CardData.m_Cost;
        display.SetMoney(Money);
        Board.BuyCard(card);
    }

    public void SelectCard(Card card)
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

    public void BuildCard(int selectedBuildingSlot)
    {
        Debug.Log($" bc1: {selectedCard} +{selectedBuildingSlot}");

        if(selectedCard != null)
        {
            Board.BuildCard(selectedCard, selectedBuildingSlot);
        }
    }

    public void DrawCardsToHand()
    {
        if(gameState == GameState.Drawing)
        {
            Board.DrawCardToHand(3);
        }
        gameState = GameState.PlayingCards;
    }

    public void EndTurn()
    {
        if(gameState == GameState.PlayingCards)
        {
            Debug.Log("end turn pressed");
            Board.DiscardHand();
            EndTurnCalculation();
            gameState = GameState.Drawing;
        }
    }

    private void EndTurnCalculation()
    {
        Polution = Board.GetEndTurnPolution();
        display.SetPolution(Polution);
    }

}
