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
    
    public CardImpact GetEndTurnImpact()
    {
        CardImpact totalImpact = new CardImpact();
        foreach(var slot in BuildingSlots)
        {
            Debug.Log("GetEndTurnPolution");
            if(slot.m_CardData)
            {
                CardImpact cardImpact = slot.GetCardCalaulation(this);
                totalImpact.polution += cardImpact.polution;
                totalImpact.population += cardImpact.population;
                totalImpact.extraCardsToDraw += cardImpact.extraCardsToDraw;
                totalImpact.eventCardsToAdd += cardImpact.eventCardsToAdd;
            }
        }
        return totalImpact;
     // see every card
     // return polution sum   
    }

}
