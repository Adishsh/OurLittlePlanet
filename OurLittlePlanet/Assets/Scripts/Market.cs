using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : CardsCollection
{
    [SerializeField] private List<Slot> slots;
    [SerializeField] private List<CardData> m_CardsData;
    [SerializeField] private List<EraList> m_EraCards;

    
    private void Start() 
    {
        ChangeEra(0);
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
    
    public Card DrawCard(Slot slot)
    {
        return base.DuplicateCard(slot);
    }

    public void ChangeEra(int eraIndex)
    {
        if(m_EraCards.Count > eraIndex)
        base.InitCardsDisplayed(m_EraCards[eraIndex].list, slots);
    }
     [System.Serializable]
    public class EraList
    {
        public List<CardData> list;
    }
}
