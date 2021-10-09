using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmBuilding : Building
{
    public override CardImpact GetCardCalaulation(StatsManager statsManager, WorldMap map)
    {
        List<BuildingSlot> AdjacentBuildings = map.GetAdjecentSlots(slot);

        List<BuildingSlot> AdjacentFarms = AdjacentBuildings.FindAll(buildingSlot => buildingSlot?.building != null && buildingSlot.building.GetType() == typeof(FarmBuilding));

        CardImpact impact = base.GetCardCalaulation(statsManager, map);

        if (AdjacentFarms.Count >= 2)
        {
            impact.resources += 1;
        }
        Debug.Log("Farm" + AdjacentFarms.Count);
        return impact;
    }
}
