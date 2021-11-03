using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsCollection : MonoBehaviour
{
    [SerializeField] private bool m_isPile;
    [SerializeField] private bool m_isFrontUp;
    [SerializeField] protected int m_maxCardAmount;
    [SerializeField] protected List<Card> m_Cards;
    [SerializeField] private Card cardPrefab;

    protected bool m_isSelectable;
    public int CardsAmount => m_Cards.Count;

    protected void InitCardsPiled(List<CardData> cardsdata, Slot slot)
    {
        foreach(CardData data in cardsdata)
        {
            InitCard(data, slot);
        }
    }

    protected void InitCardsDisplayed(List<CardData> cardsdata, List<Slot> slots)
    {
        for( int i=0; i< cardsdata.Count; i++)
        {
            InitCard(cardsdata[i], slots[i]);
        }
    }

    private void InitCard(CardData cardData, Slot slot)
    {
        Transform ParentTransform = slot.gameObject.transform;

        Card card = Instantiate(cardPrefab, ParentTransform.position, ParentTransform.rotation, ParentTransform);
        card.SetUpCard(cardData);
        slot.SetCard(card, false);
        m_Cards.Add(card);
    }

    public void SetSelectable(bool isSelectable)
    {
        m_isSelectable = isSelectable;
    }
    public void Shuffle()
    {
        for (int i = 0; i < m_Cards.Count; i++) 
        {
            Card temp = m_Cards[i];
            int randomIndex = Random.Range(i, m_Cards.Count);
            m_Cards[i] = m_Cards[randomIndex];
            m_Cards[randomIndex] = temp;
        }
    }

    public virtual void AddCard(Card card)
    {
        m_Cards.Add(card);
    }

    public void AddCards(List<Card> cards)
    {
        m_Cards.AddRange(cards);
    }

    public void RemoveCards(int index = 0)
    {
        m_Cards.RemoveAt(index);
    }



    public int GetCardIndex(Card card)
    {
        return m_Cards.IndexOf(card);
    }

    public Card DuplicateCard(Slot slot)
    {
        Card card = slot.card;
        Card newCard = Instantiate(card, card.transform.position, card.transform.rotation, slot.transform);
        newCard.SetUpCard(card.m_CardData);
        return newCard;

    }

    protected virtual Card DrawCard(int index = 0, bool shouldRemoveCard = true)
    {
        Card givenCard = m_Cards[index];
        if(shouldRemoveCard)
        RemoveCards(index);
        return givenCard;
    }

    protected virtual Card GetTopCard()
    {
        return CardsAmount>0 ? m_Cards[CardsAmount -1]: null;
    }
 
    public void Clear()
    {
        m_Cards = new List<Card>();
    }

}
