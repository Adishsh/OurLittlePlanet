using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorologyCenterBuilding : Building
{
    public override void OnTurnEnd(StatsManager statsManager, WorldMap map)
    {
        statsManager.DisplayNextEvent(true);
    }

    protected override void OnBuildingDestroy(StatsManager statsManager)
    {
        statsManager.DisplayNextEvent(false);
    }
}
