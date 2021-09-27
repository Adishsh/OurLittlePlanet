using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
   CardsCollection EventDeck;
   Deck Deck;
   Hand Hand;
   CardsCollection Discard;
   CardsCollection Market;

   int PolutionRate;
   int Money;
   int Enenrgy;

    public Board(CardsCollection eventDeck,Deck deck,Hand hand, CardsCollection discard, CardsCollection market)
    {
        EventDeck = eventDeck;
        Deck =deck;
Hand= hand;
Discard = discard;
Market = market;
    }
    public void DrawCardToHand(int cardsToDraw = 1)
    {
        for(int i =0; i< cardsToDraw; i++)
        {
            Card cardToHand = Deck.DrawCard();
            Hand.AddCard(cardToHand);
        }
    }

    public void BuildCard(Card card, int mapIndex = 0)
    {
        if(card != null)
        {
            Hand.DrawCard(card);
            //build
            Discard.AddCard(card);
        }
    }
}
