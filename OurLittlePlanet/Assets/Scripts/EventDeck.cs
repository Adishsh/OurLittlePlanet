using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventDeck : MonoBehaviour
{
    [SerializeField] private List<EventCard> m_ActiveEventCards;
    [SerializeField] private List<EventCard> m_AllEventCards;
    [SerializeField] private List<EventCard> m_EventCardsDiscard;

    [SerializeField] TMP_Text m_EventText;
    private EventCard m_NextEvent;

    private void Awake() 
    {
        m_EventCardsDiscard = new List<EventCard>();
    }

    public EventCard SetNextEvent()
    {
        if(m_ActiveEventCards.Count == 0)
        {
            m_ActiveEventCards.AddRange(m_EventCardsDiscard);
            m_EventCardsDiscard = new List<EventCard>();
        }
        int randomIndex = Random.Range(0, m_ActiveEventCards.Count);
        m_NextEvent = m_ActiveEventCards[randomIndex];
        return m_NextEvent;
    }

    public EventCard SelectEventCard()
    {
        if(m_NextEvent == null)
        {
            SetNextEvent();
        }
        m_EventText.text = m_NextEvent.m_EventName;
        m_ActiveEventCards.Remove(m_NextEvent);
        m_EventCardsDiscard.Add(m_NextEvent);
        return m_NextEvent;
    }

    public void AddEventCardToEventDeck(int eventsToAdd)
    {
        Debug.Log("bad event added:"+eventsToAdd);
        for( int i=0; i < eventsToAdd; i++)
        {
            int randomIndex = Random.Range(0, m_AllEventCards.Count);
            EventCard newEvent = m_AllEventCards[randomIndex];
            m_ActiveEventCards.Add(newEvent);
        }
    }

}
