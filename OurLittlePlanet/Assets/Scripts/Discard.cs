using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discard : CardsCollection
{
    [SerializeField] Slot slot;
    public override void AddCard(Card card)
    {
        Debug.Log($"add {card} to discard");
        card.MoveCardToNewSlot(slot);
        base.AddCard(card);
    }
}
