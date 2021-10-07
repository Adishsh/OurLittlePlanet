using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplay : MonoBehaviour
{
    [SerializeField] Text Money;
    [SerializeField] Text Resources;
    [SerializeField] Text ResourcesGoal;
    [SerializeField] Text ExtraResourcesNeeded;
    [SerializeField] Text Polution;
    [SerializeField] Text m_TempPolution;
    [SerializeField] Text m_LessResourcesNeeded;
    [SerializeField] Text m_Strikes;

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

    public void SetLessResourcesNeeded(int amount)
    {
        ExtraResourcesNeeded.gameObject.SetActive(amount != 0);
        string AdditiveSign = amount > 0 ? "+":"-";
        m_LessResourcesNeeded.text = $"{AdditiveSign} {Mathf.Abs(amount)}";
    }
}
