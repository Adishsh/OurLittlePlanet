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
            gameState = GameState.Drawing;
        }
        
    }


}
