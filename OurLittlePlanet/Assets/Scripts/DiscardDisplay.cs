using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardDisplay : CardsCollection
{
    [SerializeField] List<Slot> slots;

    private void Awake() 
    {
        Debug.Log("DiscardDisplay init ");
        foreach(Slot slot in slots)
        {
            slot.OnSelectSlotCard = () => SelectDiscardSlot(slot);
        }
        Debug.Log("DiscardDisplay done");

    }

    public Card DrawCard(Slot slot)
    {
        Card card = slot.card;
        slot.SetCard(null, false);
        slot.gameObject.SetActive(false);
        base.DrawCard(GetCardIndex(card));
        return card;
    }

    private Slot CreateNewSlot()
    {
            Slot freeSlot = slots.Find( slot => !slot.gameObject.activeSelf);
            if(freeSlot == null) 
            {
             freeSlot = slots.Find( slot => slot.card == null);                
            }
            freeSlot.gameObject.SetActive(true);
            return freeSlot;
     }

    public override void AddCard(Card card)
    {
        if(card == null)
        {
            return;
        }
        Slot slot = CreateNewSlot();
        slot.SetCard(card);
        base.AddCard(card);
    }

    public List<Card> RemoveAllCards()
    {
        var cards = m_Cards;
        foreach(Slot slot in slots)
        {         
            slot.SetCard(null, false);
            slot.gameObject.SetActive(false);
        }
        base.Clear();
        return cards;
    }

    private void SelectDiscardSlot(Slot slot)
    {
        if(slot.card != null)
        {
            Debug.Log("SelectDiscardSlot Dםמ ");
            EventManager.instance.SelectDiscardCard.Invoke(slot);
        }
    }
}
