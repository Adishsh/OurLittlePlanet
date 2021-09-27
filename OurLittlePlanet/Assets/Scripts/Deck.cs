using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : CardsCollection
{
    Card topCard;
    [SerializeField] Slot slot;

    public Card DrawCard()
    {
        Card card = base.DrawCard(0);
        return card;
    }

}
