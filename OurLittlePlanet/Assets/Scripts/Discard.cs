using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discard : CardsCollection
{
    [SerializeField] Slot slot;

    public override void AddCard(Card card)
    {
        Debug.Log($"add {card} to discard {slot}");
        card.MoveCardToNewSlot(slot);
        base.AddCard(card);
    }

    public List<Card> ShuffleAndGetCards()
    {
        base.Shuffle();
        var cards = m_Cards;
        m_Cards = new List<Card>();
        return cards;
    }
}
