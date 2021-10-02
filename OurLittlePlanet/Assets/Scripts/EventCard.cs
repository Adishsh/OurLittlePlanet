using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCard : Card
{
    public string m_EventName;
    public virtual void EventAction(WorldMap map)
    {
        Debug.Log("did event!!");
    }
}
