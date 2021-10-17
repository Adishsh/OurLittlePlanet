using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePortBuilding : Building
{
    public override void OnTurnEnd(StatsManager statsManager, WorldMap map)
    {
        EventManager.instance.WinGame.Invoke();
    }
}
