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


    private int strikes = 0;
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

    private void Awake() 
    {
        Instance = this;
    }

    private void Start() 
    {
        AddMoney(m_InitMoney);
        SetResources(m_InitResources);
        AddPolution(m_InitPolution);
        AddStrikes(strikes);
        AddCardsToDraw(m_InitCardsToDraw);
        SetNextPolutionToAddEvent();
    }

    public void SetNextPolutionToAddEvent()
    {
        nextPolutionToAddEvent += m_PolutionAmountToAddBadEvent;
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
        Debug.Log($"SetResourcesGoal:{resources}");

       m_GoalResources = resources;
        m_Display.SetResourcesNeeded(resources);
    }

    public void AddPolution(int polution)
    {
        if(polution + m_Polution < nextPolutionToAddEvent - m_PolutionAmountToAddBadEvent)
        {
            m_Polution = nextPolutionToAddEvent - m_PolutionAmountToAddBadEvent;
        }
        else
        {
            m_Polution += polution;
        }    
        m_Display.SetPolution(m_Polution);
    }

    private int GetNewEventCardsFromPolution()
    {
        if(m_Polution > nextPolutionToAddEvent)
        {
            int extraPolution = m_Polution - nextPolutionToAddEvent;
            int badEventToAdd = (int)Mathf.Ceil((float)extraPolution/m_PolutionAmountToAddBadEvent);
            nextPolutionToAddEvent += badEventToAdd * m_PolutionAmountToAddBadEvent;
            Debug.Log($"extraPolution: {extraPolution} nextPolutionToAddEvent: {nextPolutionToAddEvent}");

            Debug.Log($"GetNewEventCardsFromPolution: {badEventToAdd}");
            return badEventToAdd;
        }
        return 0;
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

    public void SetNewEventCards(int extraEventsToAdd= 0)
    {
        m_ExtraEventCardsToAdd = extraEventsToAdd;
    }

    public int GetEventCardsAmountToDraw()
    {
        return GetNewEventCardsFromPolution() + m_ExtraEventCardsToAdd;
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
            m_Display.SetLessResourcesNeeded(impact.lessResourcesNeeded);
        }
    }

    public void SetDay(int num)
    {
        m_Display.SetDay(num);
    }

    public void SetEra(int num)
    {
        m_Display.SetEra(num);
        if(strikes > 0)
        {
            strikes--;
        }
        freeDiscardCardCount =3;
    }
}
