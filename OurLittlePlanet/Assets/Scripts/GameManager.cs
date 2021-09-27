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

    enum GameState
    {
        Drawing,
        Events,
        PlayingCards,
        EndOfTurn,
    }

    private void Awake() 
    {
        Board = new Board(EventDeck, Deck, Hand, Discard, Market);
        Instance = this;
        gameState = GameState.Drawing;
    }
        
    private void SetUpGame()
    {

    }
    
    private void ActivateEvent()
    {

    }

    public void BuyCard()
    {
        
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

    public void BuildCard()
    {
        if(selectedCard != null)
        {
            Board.BuildCard(selectedCard);
        }
    }

    public void DrawCardsToHand()
    {
        if(gameState == GameState.Drawing)
        {
            Board.DrawCardToHand(5);
        }
        gameState = GameState.PlayingCards;
    }


}
