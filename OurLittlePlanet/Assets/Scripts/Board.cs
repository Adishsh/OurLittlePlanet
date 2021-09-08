using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
   CardsCollection EventDeck;
   CardsCollection Deck;
   CardsCollection Hand;
   CardsCollection Discard;
   CardsCollection Market;

   int PolutionRate;
   int Money;
   int Enenrgy;

    public void DrawCardToHand()
    {
        Card cardToHand = Deck.DrawCard(0);
        Hand.AddCard(cardToHand);
    }

    public void UseCard(int index)
    {
        Card cardToDiscard = Hand.DrawCard(index);
        Discard.AddCard(cardToDiscard);
    }
}
