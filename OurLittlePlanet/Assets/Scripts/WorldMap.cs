using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldMap : MonoBehaviour
{
    [SerializeField] private List<BuildingSlot> BuildingSlots;
    [SerializeField] int m_RowsCount;

    private void Awake() 
    {
        if(m_RowsCount * m_RowsCount != BuildingSlots.Count)
        {
            Debug.LogError($" BuildingSlots array should have {m_RowsCount * m_RowsCount} slots!");
        }

        for(var i = 0; i < BuildingSlots.Count; i ++)
        {
            BuildingSlots[i].index = i;
        }
    }

    public List<BuildingSlot> GetAdjecentSlots(BuildingSlot slot)
    {
        int index = slot.index;
        bool isInFirstRow = index < m_RowsCount;
        bool isInLastRow = index >= m_RowsCount * (m_RowsCount-1);
        bool isInFirstColumn = index % m_RowsCount == 0;
        bool isInLastColumn = index % m_RowsCount == m_RowsCount - 1;
        var slots = new List<BuildingSlot>();
        if (!isInLastRow)
        {
            slots.Add(BuildingSlots[index + m_RowsCount]);
        }
        
        if (!isInFirstRow)
        {
            slots.Add(BuildingSlots[index - m_RowsCount]);
        }
        
        if (!isInFirstColumn)
        {
            slots.Add(BuildingSlots[index -1]);
        }
        
        if (!isInLastColumn)
        {
            slots.Add(BuildingSlots[index + 1]);
        }
        return slots;
    }

    public List<BuildingSlot> GetAllSlotsWithBuildingsTypes<T>()
    {
        return BuildingSlots.FindAll((slot) => 
        {
            Building building = slot?.building;
            return building != null && building.GetType() == typeof(T);
        });
    }

    public int GetIslandCount(List<BuildingSlot> slots)
    {
        List<BuildingSlot> adjecentSlots = new List<BuildingSlot>();
        foreach(BuildingSlot slot in slots)
        {
            adjecentSlots.AddRange(GetAdjecentSlots(slot));
        }

        foreach(BuildingSlot adjecentSlot in adjecentSlots)
        {
            if(slots.Contains(adjecentSlot))
            {
                adjecentSlots.Remove(adjecentSlot);
            }
        }
        return adjecentSlots.Count;
    }

    public void BuildCard(int buildingSlotIndex, Card card)
    {
        Debug.Log(" bc ");
        BuildingSlots[buildingSlotIndex].Build(card);

    }

    public void SetSelectable(bool isSelectable)
    {

    }
    
    public void CalcEndTurnImpact(StatsManager statsManager)
    {
        CardImpact totalImpact = new CardImpact();
        foreach(var slot in BuildingSlots)
        {
            Debug.Log("GetEndTurnPolution");
            if(slot.HasCardData())
            {
                CardImpact cardImpact = slot.GetCardCalaulation(statsManager, this);
                totalImpact.polution += cardImpact.polution;
                totalImpact.resources += cardImpact.resources;
                totalImpact.extraCardsToDraw += cardImpact.extraCardsToDraw;
                totalImpact.extraEventCardsToAdd += cardImpact.extraEventCardsToAdd;
            }
        }   
            statsManager.AddPolution(totalImpact.polution);
            statsManager.SetResources(totalImpact.resources);
            statsManager.GainMoneyForRecources();
            statsManager.AddCardsToDraw(totalImpact.extraCardsToDraw);
            statsManager.SetNewEventCards(totalImpact.extraEventCardsToAdd);
    }

}
