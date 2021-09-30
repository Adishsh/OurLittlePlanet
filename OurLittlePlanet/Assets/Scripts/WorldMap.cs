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

    public void SetSelectable(bool isSelectable)
    {

    }
    
    public int GetEndTurnPolution()
    {
        int sum = 0;
        foreach(var slot in BuildingSlots)
        {
            Debug.Log("GetEndTurnPolution");
            if(slot.m_CardData)
            {
                sum +=  slot.m_CardData.m_Pollution;
            Debug.Log(sum);

            }
        }
        return sum;
     // see every card
     // return polution sum   
    }

}
