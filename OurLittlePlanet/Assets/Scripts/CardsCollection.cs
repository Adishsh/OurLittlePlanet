using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsCollection : MonoBehaviour
{
    [SerializeField] private bool m_isPile;
    [SerializeField] private bool m_isFrontUp;
    [SerializeField] protected int m_maxCardAmount;

    public bool m_isSelectable;
    public int CardsAmount => m_Cards.Count;
    [SerializeField] protected List<Card> m_Cards;

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

    protected virtual Card DrawCard(int index = 0)
    {
        Card givenCard = m_Cards[index];
        RemoveCards(index);
        return givenCard;
    }
 
    public void Clear()
    {
        m_Cards = new List<Card>();
    }

}
