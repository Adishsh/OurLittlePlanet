using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitwave : EventCard
{
    
    public override void ActivateEvent(WorldMap map, StatsManager statsManager)
    {
        statsManager.SetExtraNeededResources(10);
    }
}
