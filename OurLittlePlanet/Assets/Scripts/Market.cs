using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{
    [SerializeField] private List<Slot> slots;
    
    private void Awake() 
    {
        foreach(var slot in slots)
        {
            slot.OnSelectSlotCard = () => SelectMarketCard(slot);
        }
    }

    private void SelectMarketCard(Slot slot)
    {
        if(slot)
        {
            EventManager.instance.BuyCard.Invoke(slot);
        }
    }
}
