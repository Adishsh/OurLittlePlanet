using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmithyBuilding : Building
{
    public override CardImpact GetCardCalaulation(StatsManager statsManager, WorldMap map)
    {
        List<BuildingSlot> AdjacentBuildings = map.GetAdjecentSlots(slot);

        List<BuildingSlot> AdjacentMines = AdjacentBuildings.FindAll(buildingSlot => buildingSlot.building != null && buildingSlot.building.GetType() == typeof(MineBuilding));

        CardImpact impact = base.GetCardCalaulation(statsManager, map);

        if (AdjacentMines.Count > 0)
        {
            impact.resources += 1;

        }
        return impact;
    }
}
