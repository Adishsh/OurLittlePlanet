using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text Money;
    [SerializeField] TMP_Text Resources;
    [SerializeField] TMP_Text ResourcesGoal;
    [SerializeField] TMP_Text ExtraResourcesNeeded;
    [SerializeField] TMP_Text Polution;
    [SerializeField] TMP_Text m_TempPolution;
    [SerializeField] TMP_Text m_Day;
    [SerializeField] TMP_Text m_Era;
    [SerializeField] Animator m_EraAnimator;
    [SerializeField] LifeDisplay m_Life;
    [SerializeField] GameObject m_PolutionWarning;
    [SerializeField] GameObject m_GoalWarning;
    [SerializeField] Animator m_BadEventAddedAnimation;
    [SerializeField] TMP_Text m_NextPolutionLimit;
    [SerializeField] TMP_Text m_NextEventText;



    public void SetMoney(int amount)
    {
        Money.text = amount.ToString();
    }
  
    public void SetResources(int amount)
    {
        Resources.text = amount.ToString();
    }

    public void SetResourcesNeeded(int amount)
    {
        ResourcesGoal.text = $"{amount}";
        ResourcesGoal.gameObject.SetActive(amount > 0);
    }

    public void SetPolution(int amount)
    {
        Polution.text = amount.ToString();
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
        m_EraAnimator.Play("NewEra");
    }

    public void SetPolutionWarning(bool isOn)
    {
        m_PolutionWarning.SetActive(isOn);
    }

    public void SetGoalWarning(bool isOn)
    {
        Debug.Log("goal warning "+isOn);
        m_GoalWarning.SetActive(isOn);
    }

    public void DisplayBadEventAdded()
    {
        m_BadEventAddedAnimation?.SetTrigger("Go");
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
