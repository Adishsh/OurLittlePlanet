using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Discard : CardsCollection
{
    [SerializeField] Slot m_TopSlot;

    public void SetDiscardShow(Action SelectDIscardSlot)
    {
        m_TopSlot.OnSelectSlotCard = SelectDIscardSlot;

    }
    public override void AddCard(Card card)
    {
        m_TopSlot.SetCard(card);
        base.AddCard(card);
    }

    public List<Card> ShuffleAndGetCards()
    {
        base.Shuffle();
        var cards = m_Cards;
        m_Cards = new List<Card>();
        m_TopSlot.SetCard(null, false);
        return cards;
    }

    public void RemoveCard(Card card)
    {
        int cardIndex = GetCardIndex(card);
        RemoveCards(cardIndex);
        if(cardIndex >= CardsAmount)
        {
            Card newTopCard = CardsAmount > 0 ? m_Cards[CardsAmount -1]: null;
            m_TopSlot.SetCard(newTopCard);
        }
    }
}
