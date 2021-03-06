using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class StatsDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text Money;
    [SerializeField] TMP_Text MoneyChange;
    [SerializeField] Animator m_MoneyAdded;
    [SerializeField] TMP_Text Resources;
    [SerializeField] TMP_Text ResourcesChange;
    [SerializeField] Animator ResourcesAdded;
    [SerializeField] TMP_Text ResourcesGoal;
    [SerializeField] TMP_Text ExtraResourcesNeeded;
    [SerializeField] TMP_Text Polution;
    [SerializeField] TMP_Text PolutionChange;
    [SerializeField] Animator PolutionAdded;
    [SerializeField] TMP_Text m_TempPolution;
    [SerializeField] TMP_Text m_Day;
    [SerializeField] TMP_Text m_Era;
    [SerializeField] Animator m_EraAnimator;
    [SerializeField] LifeDisplay m_Life;
    [SerializeField] GameObject m_PolutionWarning;
    [SerializeField] GameObject m_PolutionWarning1;
    [SerializeField] GameObject m_GoalWarning;
    [SerializeField] GameObject m_GoalWarning1;
    [SerializeField] Animator m_BadEventAddedAnimation;
    [SerializeField] TMP_Text m_NextPolutionLimit;
    [SerializeField] TMP_Text m_NextEventText;


    IEnumerator DelayedAction(Action action, float seconds)
    {
        yield return new WaitForSeconds(0.25f);
        action.Invoke();
    }
    public void SetMoney(int amount, int change)
    {
        if(change != 0)
        {
            string additiveSign = change > 0?"+":"";
            MoneyChange.text = $"{additiveSign}{change.ToString()}";
            m_MoneyAdded.speed = 0.35f;
            m_MoneyAdded.SetTrigger("Show");
        }
        StartCoroutine(DelayedAction( ()=>{Money.text = amount.ToString();}, 1f));
    }
  
    public void SetResources(int amount, int change)
    {
        if(change != 0)
        {
            string additiveSign = change > 0?"+":"";
            ResourcesChange.text = $"{additiveSign}{change.ToString()}";
            ResourcesAdded.speed =1;
            ResourcesAdded.SetTrigger("Show");
        }
        StartCoroutine(DelayedAction( ()=>{Resources.text = amount.ToString();}, 1f));
    }

    public void SetResourcesNeeded(int amount)
    {
        ResourcesGoal.text = $"{amount}";
        ResourcesGoal.gameObject.SetActive(amount > 0);
    }

    public void SetPolution(int amount, int change)
    {
        if(change != 0)
        {
            string additiveSign = change > 0?"+":"";
            PolutionChange.text = $"{additiveSign}{change.ToString()}";
            PolutionAdded.speed = 0.35f;
            PolutionAdded.SetTrigger("Show");
        }
        StartCoroutine(DelayedAction( ()=>{Polution.text = amount.ToString();}, 1f));
    }

    public void SetLife(int life)
    {
        m_Life.SetLife(life);
    }

    public void SetTempPolution(int polution)
    {
        m_TempPolution.gameObject.SetActive(true);
        m_TempPolution.text = polution.ToString();
    }

    public void HideTempPolution()
    {
        m_TempPolution.gameObject.SetActive(false);
        m_TempPolution.text = "";
    }

    public void SetExtraResourcesNeeded(int amount)
    {
        ExtraResourcesNeeded?.gameObject?.SetActive(amount != 0);
        string AdditiveSign = amount > 0 ? "+":"-";
        if(ExtraResourcesNeeded != null)
        ExtraResourcesNeeded.text = $"{AdditiveSign} {Mathf.Abs(amount)}";
    }
    
    public void SetDay(int num)
    {
        m_Day.text = num.ToString();
    }

    public void SetEra(int num)
    {
        m_Era.text = num.ToString();
    }

    public void SetPolutionWarning(bool isOn)
    {
        m_PolutionWarning?.SetActive(isOn);
        m_PolutionWarning1?.SetActive(isOn);
    }

    public void SetGoalWarning(bool isOn)
    {
        Debug.Log("goal warning "+isOn);
        m_GoalWarning?.SetActive(isOn);
        m_GoalWarning1?.SetActive(isOn);
    }

    public void DisplayBadEventAdded(bool fromPolution)
    {
        string trigger = fromPolution?"AddedFromPolution" :"AddedFromCard";
        m_BadEventAddedAnimation?.SetTrigger(trigger);
        AudioManager.S.Play_Sound((AudioManager.SoundTypes.Bad_Event));
            Debug.Log($"Ron- bad event added");

    }

    public void SetNextPolutionLimit(int nextPolution)
    {
        m_NextPolutionLimit.text = nextPolution.ToString();
    }    

    public void DisplayNextEvent(bool shouldShow)
    {
        m_NextEventText.gameObject.SetActive(shouldShow);
    }  

    public void SetNextEvent(string nextEventText)
    {
        m_NextEventText.text = nextEventText;
    }    
}
