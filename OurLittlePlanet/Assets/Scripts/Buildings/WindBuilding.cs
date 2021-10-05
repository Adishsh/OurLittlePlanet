using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBuilding : Building
{
    public override CardImpact GetCardCalaulation(StatsManager statsManager, WorldMap map)
    {
        bool isRainyDay = statsManager.m_CurrentEvent.GetType() == typeof(RainyDay);

        Debug.Log($"SolarPowerBuilding - GetCardCalaulation isRainyDay: {isRainyDay}");

        CardImpact impact = base.GetCardCalaulation(statsManager, map);
        impact.resources = isRainyDay ? m_CardData.m_Resources + 2 : m_CardData.m_Resources;
        return impact;
    }
}
