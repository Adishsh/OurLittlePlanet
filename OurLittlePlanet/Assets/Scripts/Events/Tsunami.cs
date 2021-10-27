using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tsunami : EventCard
{
    
    public override void ActivateEvent(WorldMap map, StatsManager statsManager)
    {
        var slotsToDestroy = map.GetRandomFrameSlots();
        map.DestroyBuildings(slotsToDestroy);
        base.ActivateEvent(map, statsManager);
    }
}
