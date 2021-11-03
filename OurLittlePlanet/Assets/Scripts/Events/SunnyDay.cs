using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunnyDay : EventCard
{
    public override void ActivateEvent(WorldMap map, StatsManager statsManager)
    {
        statsManager.SetCurrentEvent(this);
        if(!string.IsNullOrEmpty(m_AnimationName) && m_Animator != null)
        {
            m_Animator.SetTrigger("Go");
        m_Animator.ResetTrigger("End");

        }
    }
}
