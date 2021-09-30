using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

   [SerializeField] CardsCollection m_EventDeck;
   [SerializeField] Deck m_Deck;
   [SerializeField] Hand m_Hand;
   [SerializeField] Discard m_Discard;
   [SerializeField] CardsCollection m_Market;
   [SerializeField] WorldMap m_Map;


    public void DrawCardToHand(int cardsToDraw = 1)
    {
        for(int i =0; i< cardsToDraw; i++)
        {
            if(m_Deck.CardsAmount <= 0)
            {
                RefilDeck();
            }
            Card cardToHand = m_Deck.DrawCard();
            m_Hand.AddCard(cardToHand);
        }
    }

    public void BuildCard(Card card, int mapIndex = 0)
    {
        if(card != null)
        {
            m_Hand.DrawCard(card);
            m_Map.BuildCard(mapIndex, card);
            m_Discard.AddCard(card);
        }
    }

    
    public void DiscardHand()
    {
        Debug.Log("DiscardHand");
        var cards = m_Hand.RemoveAllCards();

        foreach (Card card in cards)
        {
            m_Discard.AddCard(card);
        }
    }

    public void RefilDeck()
    {
        var cards = m_Discard.ShuffleAndGetCards();
    
        foreach(Card  card in cards)
        {
            m_Deck.AddCard(card);
        }
        Debug.Log($"RefilDeck to {m_Deck.CardsAmount}");
    }

    public void BuyCard(Card card)
    {
        m_Discard.AddCard(card);
        Debug.Log($"Discard {card}");
    }

    public int GetEndTurnPolution()
    {
        return m_Map.GetEndTurnPolution();
     // see every card
     // return polution sum   
    }
}
