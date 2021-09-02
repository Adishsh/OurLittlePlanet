using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsCollection : MonoBehaviour
{
    [SerializeField] private bool m_isPile;
    [SerializeField] private bool m_isFrontUp;
    [SerializeField] public int m_maxCardAmount {get; private set;}

    public bool m_isSelectable;
    public int CardsAmount => m_Cards.Count;
    private List<Card> m_Cards;

    public void Shuffle()
    {

    }

    public void AddCard(Card card, int index = 0)
    {
        
    }

    public void AddCards(List<Card> cards, int index = 0)
    {
        
    }

    public void RemoveCards(int index = 0)
    {
        
    }

    public Card DrawCard(int index = 0)
    {
       Card givenCard = m_Cards[index];
       m_Cards.RemoveAt(0);
       return givenCard;
    }
 
    public void Clear()
    {
        
    }

}
