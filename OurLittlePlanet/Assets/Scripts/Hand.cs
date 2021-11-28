using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : CardsCollection
{
    [SerializeField] public List<Slot> slots;

    private void Awake() 
    {
        foreach(Slot slot in slots)
        {
            slot.OnSelectSlotCard = () => SelectHandSlot(slot);
        }
    }

    public Card DrawCard(Slot slot)
    
    {
        AudioManager.S.Play_Sound((AudioManager.SoundTypes.Click_02));
        Card card = slot.card;
        card.allowDrag = false;
        slot.SetCard(null, false);
        slot.gameObject.SetActive(false);
        base.DrawCard(GetCardIndex(card));
        return card;
    }

    private Slot CreateNewSlot()
    {
        //instanciateSlot
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
        card.Flip(true);
        Slot slot = CreateNewSlot();
        slot.SetCard(card);
        card.allowDrag = true;
        base.AddCard(card);
    }

    public List<Card> RemoveAllCards()
    {
        var cards = m_Cards;
        foreach(Slot slot in slots)
        {    
            if(slot != null && slot.card != null)     
            slot.card.allowDrag = false;
            
            slot.SetCard(null, false);
            slot.gameObject.SetActive(false);
            
        }
        base.Clear();
        return cards;
    }

    private void SelectHandSlot(Slot slot)
    {
        if(slot.card != null && m_isSelectable)
        {
            AudioManager.S.Play_Sound((AudioManager.SoundTypes.Click_01));
            EventManager.instance.SelectCard.Invoke(slot);
        }
    }
}
