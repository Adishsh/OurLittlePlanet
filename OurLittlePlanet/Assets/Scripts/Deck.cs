using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : CardsCollection
{
    Card topCard;
    [SerializeField] Slot slot;

    public Card DrawCard()
    {
        Card card = base.DrawCard(CardsAmount -1);
        return card;
    }

    public override void AddCard(Card card)
    {
        Debug.Log($"add {card} to deck");
        card.MoveCardToNewSlot(slot);
        base.AddCard(card);
    }

}
