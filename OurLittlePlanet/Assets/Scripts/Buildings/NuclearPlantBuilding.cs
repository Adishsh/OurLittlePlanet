using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearPlantBuilding : Building
{
    protected override void OnBuildingDestroy(StatsManager statsManager)
    {
        statsManager.AddPolution(10);
        base.OnBuildingDestroy(statsManager);
    }
}
