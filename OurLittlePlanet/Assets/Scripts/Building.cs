using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public CardData m_CardData {get; set;}
     public virtual CardImpact GetCardCalaulation(WorldMap map)
    {
        Debug.Log("GetCardCalaulation");
        return new CardImpact()
        {
            polution = m_CardData.m_Pollution,
            resources = m_CardData.m_Resources,
        };
    }
}
