using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventDeck : MonoBehaviour
{
    [SerializeField] private List<EventCard> m_ActiveEventCards;
    [SerializeField] private List<EventCard> m_AllEventCards;
    [SerializeField] Text m_EventText;


    public EventCard SelectEventCard()
    {
        int randomIndex = Random.Range(0, m_ActiveEventCards.Count);
        var nextEventCard = m_ActiveEventCards[randomIndex];
        m_EventText.text = nextEventCard.m_EventName;
        return nextEventCard;
    }

    public void AddEventCardToEventDeck(int eventsToAdd)
    {
        Debug.Log("bad event added");
        for( int i=0; i < eventsToAdd; i++)
        {
            int randomIndex = Random.Range(0, m_AllEventCards.Count);
            EventCard newEvent = m_AllEventCards[randomIndex];
            m_ActiveEventCards.Add(newEvent);
        }
    }

}
