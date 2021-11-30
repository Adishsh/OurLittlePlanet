using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : EventCard
{
    
    public override void ActivateEvent(WorldMap map, StatsManager statsManager)
    {
        StartCoroutine(DelayedAction(()=>DestroyBuildings(map),1.5f));
        statsManager.SetCurrentEvent(this);
        
        if(m_Animator != null)
        {
            m_Animator.SetTrigger("Go");
            //m_Animator.ResetTrigger("End");
        }
    }
    private void DestroyBuildings(WorldMap map)
    {
        var slotsToDestroy = map.GetRandom3x3();
        map.DestroyBuildings(slotsToDestroy);
    }
    
    IEnumerator DelayedAction(Action action, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        action.Invoke();
    }
}
