using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCard: MonoBehaviour
{
    public string m_EventName;
    public virtual void ActivateEvent(WorldMap map, StatsManager statsManager)
    {
        statsManager.SetCurrentEvent(this);
    }
}
