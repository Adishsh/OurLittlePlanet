using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : EventCard
{
    
    public override void ActivateEvent(WorldMap map, StatsManager statsManager)
    {
        var slotsToDestroy = map.GetRandomRowOrColumn(out int index);
        map.DestroyBuildings(slotsToDestroy);
        statsManager.SetCurrentEvent(this);
        if(!string.IsNullOrEmpty(m_AnimationName) && m_Animator != null)
        {
            Debug.Log("animate event:" + m_AnimationName);
            m_Animator.SetInteger("Column", index);
        m_Animator.SetTrigger("Go");

        }
    }
}
