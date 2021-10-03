using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSlot : MonoBehaviour
{
    [SerializeField] int index;
    public List<BuildingSlot> m_AdjasentSlots {get; private set;} 
    private Building building;

    public BuildingSlot(List<BuildingSlot> adjasentSlots)
    {
        m_AdjasentSlots = adjasentSlots;
    }
    public void Build(Card card)
    {
        DestroyBuilding();
        Debug.Log($"cardP ={card.m_CardData.m_Pollution}");
        var cardData = card.m_CardData;
        building = cardData.m_Building;
        if(building)
        {
            Vector3 newPosition = transform.position + building.transform.position;
            var newRotation= building.transform.rotation * transform.rotation;
            building = Instantiate(building, newPosition, newRotation, transform);
            building.GetComponent<Renderer>().material.color = card.m_CardData.m_Color;
            building.m_CardData = cardData;
        }
    }
    
    public void DestroyBuilding()
    {
        if(building != null)
        {
            building.m_CardData = null;
            Destroy(building.gameObject);
            building = null;
        }
    }

    public bool HasCardData()
    {
        return building?.m_CardData != null;
    }

    private void OnMouseUp()
    {
        EventManager.instance.BuildCard.Invoke(index);
    }
    
    public CardImpact GetCardCalaulation(StatsManager statsManager, WorldMap map)
    {
        return building?.GetCardCalaulation(statsManager, map);
    }
}
