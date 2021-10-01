using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

   [SerializeField] CardsCollection m_EventDeck;
   [SerializeField] Deck m_Deck;
   [SerializeField] Hand m_Hand;
   [SerializeField] Discard m_Discard;
   [SerializeField] Market m_Market;
   [SerializeField] WorldMap m_Map;

    public void InitBoard()
    {

    }

    public void SetDrwaingSelectable(bool isSelectable)
    {
        m_Deck.SetSelectable(isSelectable);
    }

    public void SetPlayingSelectable(bool isSelectable)
    {
        m_Hand.SetSelectable(isSelectable);
        m_Market.SetSelectable(isSelectable);
        m_Hand.SetSelectable(isSelectable);
    }

    public void SetBuildSelectable(bool isSelectable)
    {
        m_Map.SetSelectable(isSelectable);
    }

    public void DrawCardToHand(int cardsToDraw = 1)
    {
        for(int i =0; i< cardsToDraw; i++)
        {
            Card cardToHand = m_Deck.DrawCard();
            m_Hand.AddCard(cardToHand);
            if(m_Deck.CardsAmount == 0)
            {
                RefilDeck();
            }
        }
    }

    public void BuildCard(Slot slot, int mapIndex = 0)
    {
        Card card = m_Hand.DrawCard(slot);
        if(card != null)
        {
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

    public void BuyCard(Slot slot)
    {
        Card card= slot.card;
        m_Market.DrawCard(slot);
        m_Discard.AddCard(card);
        Debug.Log($"Discard {card}");
    }

    public CardImpact GetEndTurnImpact()
    {
        return m_Map.GetEndTurnImpact();
     // see every card
     // return polution sum   
    }
}
