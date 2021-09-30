using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : CardsCollection
{
    [SerializeField] private List<Slot> slots;
    
    private void Awake() 
    {
        foreach(var slot in slots)
        {
            slot.OnSelectSlotCard = () => SelectMarketCard(slot);
            var card = slot.card;
            if(card)
            {
                base.AddCard(card);
            }
        }
    }

    private void SelectMarketCard(Slot slot)
    {
        if(slot.card && m_isSelectable)
        {
            EventManager.instance.BuyCard.Invoke(slot);
        }
    }
    
    public void DrawCard(Slot slot)
    {
        Card card = slot.card;
        base.DrawCard(GetCardIndex(slot.card));
    }
}
