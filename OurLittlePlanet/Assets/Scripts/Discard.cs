using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discard : CardsCollection
{
    [SerializeField] Slot m_TopSlot;

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
}
