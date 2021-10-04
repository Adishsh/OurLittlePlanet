using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatsManager: MonoBehaviour
{
   [SerializeField] private StatsDisplay m_Display;
   [SerializeField] int m_InitMoney = 1000;
   [SerializeField] int m_InitResources = 1000;   
   [SerializeField] int m_InitPolution = 0;
   [SerializeField] int m_StrikesAllowed = 3;
   [SerializeField] int m_InitCardsToDraw = 5;

   private int strikes = 0;
   public int m_Money { get; private set; }
   public int m_Resources { get; private set; }
   public int m_Polution { get; private set; }
   public int m_CardsToDraw { get; private set; }
   public EventCard m_CurrentEvent { get; private set; }
   public Action m_AddEventCardToEventDeck { get; private set; }
   public int m_ExtraNeededResources{ get; private set; }

    private void Start() 
    {
        AddMoney(m_InitMoney);
        SetResources(m_InitResources);
        SetPolution(m_InitPolution);
        AddStrikes(strikes);
        AddCardsToDraw(m_InitCardsToDraw);
    }

    public void AddMoney(int addedMoney)
    {
        m_Money += addedMoney;
        m_Display.SetMoney(m_Money);
    }

    public void SetResources(int resources)
    {
        m_Resources = resources;
        m_Display.SetResources(resources);
    }

    public void SetExtraResources(int resources)
    {
       m_ExtraNeededResources = resources;
        m_Display.SetResources(resources);
    }

    public void SetResourcesGoal(int resources)
    {
       m_ExtraNeededResources = resources;
        m_Display.SetResourcesNeeded(resources);
    }

    public void SetPolution(int polution)
    {
        m_Polution = polution;     
        m_Display.SetPolution(polution);
    }
    
    public void AddCardsToDraw(int extraCardsAmount)
    {
        Debug.Log($"AddCardsToDraw:{extraCardsAmount}");
        m_CardsToDraw += extraCardsAmount;
    }

    public void SetCurrentEvent(EventCard currentEvent)
    {
        m_CurrentEvent = currentEvent;
    }

    public void AddStrikes(int strikesToAdd = 1)
    {
        strikes += strikesToAdd;
        m_Display.SetStrikes(strikes);
    }

    public bool DidStrikeOut()
    {
        return strikes >= m_StrikesAllowed;
    }
}
