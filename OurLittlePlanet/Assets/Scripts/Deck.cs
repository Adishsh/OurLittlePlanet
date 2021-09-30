using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : CardsCollection
{
    Card topCard;
    [SerializeField] Slot slot;

    private void Awake() 
    {
        slot.OnSelectSlotCard = SelectDeckSlot;
    }
    public Card DrawCard()
    {
        Card card = base.DrawCard(CardsAmount -1);
        return card;
    }

    public override void AddCard(Card card)
    {
        card.MoveCardToNewSlot(slot);
        base.AddCard(card);
    }

    private void SelectDeckSlot()
    {
        EventManager.instance.DrawCards.Invoke();
    }

}
