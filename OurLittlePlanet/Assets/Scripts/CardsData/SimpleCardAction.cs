using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCardAction
{
    public virtual CardImpact GetCardCalaulation(CardData data, WorldMap map)
    {
        return new CardImpact()
        {
            polution = data.m_Pollution,
            population = data.m_Resources,
        };
    }
}
