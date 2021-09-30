using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplay : MonoBehaviour
{
    [SerializeField] Text Money;
    [SerializeField] Text Population;
    [SerializeField] Text Polution;

    public void SetMoney(int amount)
    {
        Money.text = amount.ToString();
    }
  
    public void SetPopulation(int amount)
    {
        Population.text = amount.ToString();
    }
    
    public void SetPolution(int amount)
    {
        Polution.text = amount.ToString();
    }
}
