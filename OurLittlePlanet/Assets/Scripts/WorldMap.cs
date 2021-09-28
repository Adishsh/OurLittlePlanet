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

}
