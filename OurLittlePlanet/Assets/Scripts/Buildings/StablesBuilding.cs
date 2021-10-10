using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StablesBuilding : Building
{
    public override CardImpact GetCardCalaulation(StatsManager statsManager, WorldMap map)
    {
        List<BuildingSlot> AllStables = map.GetAllSlotsWithBuildingsTypes<StablesBuilding>();
        Debug.Log("StablesBuilding near slots:"+AllStables.Count);
        int numOfStables = map.GetIslandCount(AllStables, true);
        Debug.Log("numOfStables :"+numOfStables);
        
        CardImpact impact = base.GetCardCalaulation(statsManager, map);
        if (numOfStables >= 3)
        {
            impact.extraCardsToDraw = 1;
        }
        return impact;
    }
}
