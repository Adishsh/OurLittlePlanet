using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivistTentBuilding : Building
{
    public override CardImpact GetCardCalaulation(StatsManager statsManager, WorldMap map)
    {
        List<BuildingSlot> AllSlots = map.GetAllSlots();

        List<BuildingSlot> AllNonPollut = AllSlots.FindAll(slots => slots?.building?.m_CardData?.m_Pollution == 0);

        CardImpact impact = base.GetCardCalaulation(statsManager, map);

        impact.resources += AllNonPollut.Count;

        return impact;
    }

    
    public override bool CanBuildBuilding(WorldMap map)
    {
        var tents = map.GetAllSlotsWithBuildingsTypes<ActivistTentBuilding>();
        return tents.Count == 0;
    }
}
