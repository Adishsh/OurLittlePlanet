using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : EventCard
{
    
    public override void ActivateEvent(WorldMap map, StatsManager statsManager)
    {
        var slotsToDestroy = map.GetRandomRowOrColumn();
        map.DestroyBuildings(slotsToDestroy);
        base.ActivateEvent(map, statsManager);
    }
}
