using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatsManager: MonoBehaviour
{
    public static StatsManager Instance;
   [SerializeField] private StatsDisplay m_Display;
   [SerializeField] int m_InitMoney = 1000;
   [SerializeField] int m_InitResources = 1000;   
   [SerializeField] int m_InitPolution = 0;
   [SerializeField] int m_StrikesAllowed = 3;
   [SerializeField] int m_InitCardsToDraw = 5;
   [SerializeField] float m_MoneyGivenPerRecource = 10f;
   [SerializeField] int m_PolutionAmountToAddBadEvent = 10;
   [SerializeField] int m_InitLife = 3;


    private int life = 0;
    public int m_Money { get; private set; }
    public int m_Resources { get; private set; }
    public int m_Polution { get; private set; }
    public int m_CardsToDraw { get; private set; }
    public EventCard m_CurrentEvent { get; private set; }
    public int m_ExtraNeededResources{ get; private set; }
    public int m_GoalResources{ get; private set; }
    public int m_ExtraEventCardsToAdd{ get; private set; }
    public int freeDiscardCardCount;
    private int nextPolutionToAddEvent;
    private EventCard m_nextEvent;
    public bool CardIsDragged;
    public BuildingSlot buildingSlotSelected;


    private void Awake() 
    {
        Instance = this;
    }

    private void Start() 
    {
        AddMoney(m_InitMoney);
        SetResources(m_InitResources);
        AddPolution(m_InitPolution);
        AddLife(m_InitLife);
        SetExtraCardsToDraw(0);
        SetNextPolutionToAddEvent();
    }

    public void SetNextPolutionToAddEvent()
    {
        nextPolutionToAddEvent += m_PolutionAmountToAddBadEvent;
        m_Display.SetNextPolutionLimit(nextPolutionToAddEvent);
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

    public void GainMoneyForRecources()
    {
        AddMoney(Mathf.RoundToInt(m_MoneyGivenPerRecource * m_Resources));
    }

    public void SetResourcesGoal(int resources)
    {
       m_GoalResources = resources;
        m_Display.SetResourcesNeeded(resources);
    }

    public void AddPolution(int polution)
    {
        int lastPolutionLimitation = nextPolutionToAddEvent - m_PolutionAmountToAddBadEvent;
        if(polution< 0 && polution + m_Polution < lastPolutionLimitation)
        {
            m_Polution = lastPolutionLimitation;
        }
        else
        {
            m_Polution += polution;
        }    
        m_Display.SetPolution(m_Polution);
    }

    private int GetNewEventCardsFromPolution()
    {
        if(m_Polution >= nextPolutionToAddEvent)
        {
            int extraPolution = m_Polution - nextPolutionToAddEvent;
            int badEventToAdd = Mathf.Max(1,(int)Mathf.Ceil((float)extraPolution/m_PolutionAmountToAddBadEvent));
            nextPolutionToAddEvent += badEventToAdd * m_PolutionAmountToAddBadEvent;
            m_Display.SetNextPolutionLimit(nextPolutionToAddEvent);
            return badEventToAdd;
        }
        return 0;
    }
    
    public void SetExtraCardsToDraw(int extraCardsAmount)
    {
        m_CardsToDraw = m_InitCardsToDraw + extraCardsAmount;
    }

    public void SetCurrentEvent(EventCard currentEvent)
    {
        m_CurrentEvent = currentEvent;
    }

    public void AddLife(int LifeToAdd = -1)
    {
        life += LifeToAdd;
        m_Display.SetLife(life);
    }

    public bool DidStrikeOut()
    {
        return life <= 0;
    }

    public void SetNewEventCards(int extraEventsToAdd= 0)
    {
        m_ExtraEventCardsToAdd = extraEventsToAdd;
    }

    public int GetEventCardsAmountToDraw()
    {
        return GetNewEventCardsFromPolution() + m_ExtraEventCardsToAdd;
    }

    public void SetExtraNeededResources(int extraResourcesNeeded)
    {
        m_ExtraNeededResources = extraResourcesNeeded;
        m_Display.SetExtraResourcesNeeded(m_ExtraNeededResources);
    }
    
    public void SetTempCardImpact(CardImpact impact)
    {
        if(impact == null) 
        {
            m_Display.HideTempPolution();
        } 
        else
        {
            m_Display.SetTempPolution(impact.polution);
            m_Display.SetResources(impact.resources);
            DisplayWarnings(impact.polution, impact.resources);
        }
    }

    public void SetDay(int num)
    {
        m_Display.SetDay(num);
    }

    public void SetEra(int num)
    {
        Debug.Log("next era");
        m_Display.SetEra(num);
        if(life < m_InitLife)
        {
            AddLife(1);
        }
        freeDiscardCardCount =3;
    }

    public void DisplayWarnings(int newPolution, int CurrentResources)
    {
     //   Debug.Log($"m_Polution + newPolution{m_Polution +newPolution} >= {nextPolutionToAddEvent}");
      //  Debug.Log($"CurrentResources {CurrentResources} < {m_GoalResources} + {m_ExtraNeededResources}");
        m_Display.SetPolutionWarning(m_Polution + newPolution >= nextPolutionToAddEvent);
        m_Display.SetGoalWarning(CurrentResources < m_GoalResources + m_ExtraNeededResources);
    }

    public void BadEventAdded()
    {
        m_Display.DisplayBadEventAdded();
    }

    public void DisplayNextEvent(bool show)
    {
        m_Display.DisplayNextEvent(show);
    }

    public void SetNextEvent(EventCard nextEvent)
    {
        m_nextEvent = nextEvent;
        m_Display.SetNextEvent(nextEvent.m_EventName);
    }
}
