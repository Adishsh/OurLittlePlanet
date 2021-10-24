using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormyDay : EventCard
{
    
    public override void ActivateEvent(WorldMap map, StatsManager statsManager)
    {
        statsManager.SetExtraNeededResources(5);
        base.ActivateEvent(map, statsManager);
    }
}
