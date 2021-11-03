using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintingPressBuilding : Building
{
    public override CardImpact GetCardCalaulation(StatsManager statsManager, WorldMap map)
    {
        List<BuildingSlot> AllPresses = map.GetAllSlotsWithBuildingsTypes<PrintingPressBuilding>();
        int numOfPressesIslands = map.GetIslandCount(AllPresses, true);
        CardImpact impact = base.GetCardCalaulation(statsManager, map);
        if (numOfPressesIslands >= 3)
        {
            impact.extraCardsToDraw = 2;
        }
        return impact;
    }
}
