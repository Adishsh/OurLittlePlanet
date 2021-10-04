using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
            statsManager.SetPolution(totalImpact.polution);
            statsManager.SetResources(totalImpact.resources);
            statsManager.GainMoneyForRecources();
            statsManager.AddCardsToDraw(totalImpact.extraCardsToDraw);
            statsManager.SetNewEventCards(totalImpact.extraEventCardsToAdd);
    }

}
