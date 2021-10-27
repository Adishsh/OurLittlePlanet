using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPowerBuilding : Building
{
    public override CardImpact GetCardCalaulation(StatsManager statsManager, WorldMap map)
    {
        bool isRainyDay = statsManager.m_CurrentEvent.GetType() == typeof(RainyDay) ||  statsManager.m_CurrentEvent.GetType() == typeof(StormyDay);

        Debug.Log($"SolarPowerBuilding - GetCardCalaulation isRainyDay: {isRainyDay}");
        
        CardImpact impact = base.GetCardCalaulation(statsManager, map);
        impact.resources = isRainyDay ? 0 : m_CardData.m_Resources;
        return impact;
    }
}
