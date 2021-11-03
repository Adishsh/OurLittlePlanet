using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : EventCard
{
    
    public override void ActivateEvent(WorldMap map, StatsManager statsManager)
    {
        var slotsToDestroy = map.GetRandom3x3();
        map.DestroyBuildings(slotsToDestroy);
        statsManager.SetCurrentEvent(this);
        
        if(m_Animator != null)
        {
            m_Animator.SetTrigger("Go");
            //m_Animator.ResetTrigger("End");
        }
    }
}
