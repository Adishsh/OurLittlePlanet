using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunnyDay : EventCard
{
    public override void ActivateEvent(WorldMap map, StatsManager statsManager)
    {
        statsManager.SetCurrentEvent(this);
        if (m_Animator != null)
        {
            m_Animator.SetTrigger("Go");
        }
    }
}
