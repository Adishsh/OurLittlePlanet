using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPowerBuilding : Building
{
    public override CardImpact GetCardCalaulation(StatsManager statsManager, WorldMap map)
    {
        bool isRainyDay = statsManager.m_CurrentEvent.GetType() == typeof(RainyDay);
        Debug.Log($"SolarPowerBuilding - GetCardCalaulation isRainyDay: {isRainyDay}");

        return new CardImpact()
        {
            polution = m_CardData.m_Pollution,
            resources = isRainyDay ? 0 : m_CardData.m_Resources,
        };
    }
}
