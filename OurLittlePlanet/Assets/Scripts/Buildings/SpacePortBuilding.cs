using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePortBuilding : Building
{
    [SerializeField] Animator m_Animator;
    [SerializeField] ParticleSystem m_Smoke;
    public override void OnTurnEnd(StatsManager statsManager, WorldMap map)
    {
        m_Animator.SetTrigger("Go");
        EventManager.instance.WinGame.Invoke();
        m_Smoke.Emit(50);
        StartCoroutine(ShowTrail(5));
    }
    IEnumerator ShowTrail(int timesLeft)
    {
        yield return new WaitForSeconds(.5f);
        if(timesLeft >0)
        {
            m_Smoke.Emit(50);
            Debug.Log("Emit"+m_Smoke.particleCount);
            StartCoroutine(ShowTrail(timesLeft -1));
        }
    }
    
}
