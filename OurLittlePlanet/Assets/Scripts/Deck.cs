using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : CardsCollection
{
    [SerializeField] Slot m_TopSlot;
    [SerializeField] List<CardData> m_CardsData;
    
    private void Start() 
    {
        base.InitCardsPiled(m_CardsData, m_TopSlot);
        m_TopSlot.SetCard(base.GetTopCard(), false);
        m_TopSlot.OnSelectSlotCard = SelectDeckSlot;
    }

    public Card DrawCard()
    {
        Card card = base.DrawCard(CardsAmount -1);
        m_TopSlot.SetCard(base.GetTopCard(), false);
        return card;
    }

    public override void AddCard(Card card)
    {
        Debug.Log("AddCard to deck");
        m_TopSlot.SetCard(card);
        base.AddCard(card);
    }

    private void SelectDeckSlot()
    {
        if(m_isSelectable)
        {
            EventManager.instance.DrawCards.Invoke();
        }
    }

}
