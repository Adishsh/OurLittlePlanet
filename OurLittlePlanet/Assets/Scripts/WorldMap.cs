using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMap : MonoBehaviour
{
    [SerializeField] private List<BuildingSlot> BuildingSlots;
    [SerializeField] int width;
    [SerializeField] int height;

    public void BuildCard(int buildingSlotIndex, Card card)
    {
        Debug.Log(" bc ");
        BuildingSlots[buildingSlotIndex].Build(card);
    }

    
    public int GetEndTurnPolution()
    {
        int sum = 0;
        foreach(var slot in BuildingSlots)
        {
            Debug.Log("GetEndTurnPolution");
            if(slot.cardData)
            {
                sum +=  slot.cardData.m_Pollution;
            Debug.Log(sum);

            }
        }
        return sum;
     // see every card
     // return polution sum   
    }

}
