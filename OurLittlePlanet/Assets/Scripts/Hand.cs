using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : CardsCollection
{
    Card topCard;
    [SerializeField] List<Slot> slots;

    public Card DrawCard(Card card)
    {
            base.DrawCard(GetCardIndex(card));
            return card;
    }

    private Slot CreateNewSlot()
    {
        //instanciateSlot
        if(slots.Count <= m_maxCardAmount)
        {
            Slot freeSlot = slots.Find( slot => !slot.gameObject.activeSelf);
            if(freeSlot == null) 
            {
             freeSlot = slots.Find( slot => !slot.card);                
            }
            freeSlot.gameObject.SetActive(true);
            return freeSlot;
        }
        return null;
    }

    public override void AddCard(Card card)
    {
        if(card == null)
        {
            return;
        }
        card.MoveCardToNewSlot(CreateNewSlot());
        base.AddCard(card);
    }

    public List<Card> RemoveAllCards()
    {
        var cards = m_Cards;
        base.Clear();
        return cards;
    }
}
