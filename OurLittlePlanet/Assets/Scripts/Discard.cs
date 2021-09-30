using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discard : CardsCollection
{
    [SerializeField] Slot slot;

    public override void AddCard(Card card)
    {
        card.MoveCardToNewSlot(slot);
        base.AddCard(card);
    }

    public List<Card> ShuffleAndGetCards()
    {
        Debug.Log($"shuffle {m_Cards[0]}");

        base.Shuffle();
        Debug.Log($"shuffle {m_Cards[0]}");

        var cards = m_Cards;
        m_Cards = new List<Card>();
        return cards;
    }
}
