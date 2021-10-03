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

   public int m_Money { get; private set; }
   public int m_Resources { get; private set; }
   public int m_Polution { get; private set; }
   public int m_CardsToDraw { get; private set; }
   public EventCard m_CurrentEvent { get; private set; }
   public Action m_AddEventCardToEventDeck { get; private set; }

    private void Start() 
    {
        AddMoney(m_InitMoney);
        SetResources(m_InitResources);
        SetPolution(m_InitPolution);
        m_CardsToDraw = 1;
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

    public void SetPolution(int polution)
    {
        m_Polution = polution;     
        m_Display.SetPolution(polution);
    }
    
    public void SetCardsToDraw(int extraCardsAmount)
    {
        m_CardsToDraw = extraCardsAmount + 1;
    }

    public void SetCurrentEvent(EventCard currentEvent)
    {
        m_CurrentEvent = currentEvent;
    }
}
