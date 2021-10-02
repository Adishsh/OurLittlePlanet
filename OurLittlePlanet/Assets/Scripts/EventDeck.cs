using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDeck : MonoBehaviour
{
    [SerializeField] private List<EventCard> eventCards;

    public EventCard GetEventCard()
    {
        int randomIndex = Random.Range(0, eventCards.Count);
        return eventCards[randomIndex];
    }

}
