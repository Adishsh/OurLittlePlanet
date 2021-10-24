using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCard: MonoBehaviour
{
    [SerializeField] public Animator m_Animator;
    [SerializeField] public string m_AnimationName;
    
    public string m_EventName;

    public virtual void ActivateEvent(WorldMap map, StatsManager statsManager)
    {
        statsManager.SetCurrentEvent(this);
        if(!string.IsNullOrEmpty(m_AnimationName) && m_Animator != null)
        m_Animator.Play(m_AnimationName);
    }
}
