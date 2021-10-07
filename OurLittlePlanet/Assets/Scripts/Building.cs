using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Building : MonoBehaviour
{
    public Action DestroyBuilding;
    public CardData m_CardData {get; set;}
    
    public virtual CardImpact GetCardCalaulation(StatsManager statsManager, WorldMap map)
    {
        Debug.Log("GetCardCalaulation");
        DestroyBuilding = () => OnBuildingDestroy(statsManager);
        return new CardImpact()
        {
            polution = m_CardData.m_Pollution,
            resources = m_CardData.m_Resources,
        };
    }

    protected virtual void OnBuildingDestroy(StatsManager statsManager)
    {
        m_CardData = null;
    }


}