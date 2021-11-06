using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiscardDisplay : CardsCollection
{
    [SerializeField] List<Slot> slots;
     [SerializeField] TMP_Text m_Cost;
     [SerializeField] GameObject m_FreeTitle;
     [SerializeField] GameObject m_NonFreeTitle;


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
        SetTitle();
        return card;
    }

    public void SetTitle()
    {
        bool hasFree = StatsManager.Instance.freeDiscardCardCount > 0;
        int cost = StatsManager.Instance.m_Era*10 +10;
        m_FreeTitle.SetActive(hasFree);
        m_NonFreeTitle.SetActive(!hasFree);
        m_Cost.text = cost.ToString();

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
        SetTitle();
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
