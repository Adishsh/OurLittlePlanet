using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivistTentBuilding : Building
{
    public override CardImpact GetCardCalaulation(StatsManager statsManager, WorldMap map)
    {
        List<BuildingSlot> AllSlots = map.GetAdjecentSlots(this.slot);

        List<BuildingSlot> AllPolluting = AllSlots.FindAll(slots => slots?.building?.m_CardData?.m_Pollution > 0);

        CardImpact impact = base.GetCardCalaulation(statsManager, map);

        if(AllPolluting.Count == 0)
        {
            impact.resources += 4;
        }
        
        //impact.resources += AllNonPollut.Count + 1;

        return impact;
    }

    
    public override bool CanBuildBuilding(WorldMap map)
    {
        var tents = map.GetAllSlotsWithBuildingsTypes<ActivistTentBuilding>();
        return tents.Count == 0;
    }
}
