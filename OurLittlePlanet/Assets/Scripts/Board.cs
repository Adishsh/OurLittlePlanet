using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
   CardsCollection EventDeck;
   Deck Deck;
   Hand Hand;
   Discard Discard;
   CardsCollection Market;
   WorldMap Map;

   int PolutionRate;
   int Money;
   int Enenrgy;

    public Board(CardsCollection eventDeck,Deck deck,Hand hand, Discard discard, CardsCollection market, WorldMap map)
    {
        EventDeck = eventDeck;
        Deck =deck;
Hand= hand;
Discard = discard;
Market = market;
Map = map;
    }
    public void DrawCardToHand(int cardsToDraw = 1)
    {
        for(int i =0; i< cardsToDraw; i++)
        {
            if(Deck.CardsAmount <= 0)
            {
                RefilDeck();
            }

            Card cardToHand = Deck.DrawCard();
            Hand.AddCard(cardToHand);
        }
    }

    public void BuildCard(Card card, int mapIndex = 0)
    {
        if(card != null)
        {
            Hand.DrawCard(card);
            Map.BuildCard(mapIndex, card);
            Discard.AddCard(card);
        }
    }

    
    public void DiscardHand()
    {
        Debug.Log("DiscardHand");
        var cards = Hand.RemoveAllCards();

        foreach (Card card in cards)
        {
            Discard.AddCard(card);
        }
    }

    public void RefilDeck()
    {
        var cards = Discard.ShuffleAndGetCards();
    
        foreach(Card  card in cards)
        {
            Deck.AddCard(card);
        }
        Debug.Log($"RefilDeck to {Deck.CardsAmount}");
    }

    public void BuyCard(Card card)
    {
        Discard.AddCard(card);
        Debug.Log($"Discard {card}");
    }

    
}
