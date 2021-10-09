using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticMeltdownBuilding : Building
{
    public override CardImpact GetCardCalaulation(StatsManager statsManager, WorldMap map)
    {
        CardImpact impact = base.GetCardCalaulation(statsManager, map);

        impact.extraEventCardsToAdd = 1;

        return impact;
    }
}
