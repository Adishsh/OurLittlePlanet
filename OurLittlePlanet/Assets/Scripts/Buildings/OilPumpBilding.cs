using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilPumpBilding : Building
{
    int turnCount =0;
        // for now for Oil Pump and Activist's Tent	
    public override void OnTurnEnd(StatsManager statsManager, WorldMap map)
    {
        turnCount++;
        if(turnCount >= 3)
        {
            map.DestroyBuilding(slot.index);
        }
    }
}
