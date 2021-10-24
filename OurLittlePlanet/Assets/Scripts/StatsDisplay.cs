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
    [SerializeField] Text ExtraResourcesNeeded;
    [SerializeField] TMP_Text Polution;
    [SerializeField] TMP_Text m_TempPolution;
    [SerializeField] Text m_LessResourcesNeeded;
    [SerializeField] TMP_Text m_Strikes;
    [SerializeField] TMP_Text m_Day;
    [SerializeField] TMP_Text m_Era;


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

    public void SetStrikes(int strike)
    {
        m_Strikes.text = strike.ToString();
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
        if(m_LessResourcesNeeded != null)
        m_LessResourcesNeeded.text = $"{AdditiveSign} {Mathf.Abs(amount)}";
    }
    
    public void SetDay(int num)
    {
        m_Day.text = num.ToString();
    }

    public void SetEra(int num)
    {
        m_Era.text = num.ToString();
    }
}
