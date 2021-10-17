using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSlot : MonoBehaviour
{
    [SerializeField]public int index;
    public List<BuildingSlot> m_AdjasentSlots {get; private set;} 
    public Building building{ get; private set;}
    public bool WasCalculated = false;
    [SerializeField] Animator animator;


    public BuildingSlot(List<BuildingSlot> adjasentSlots)
    {
        m_AdjasentSlots = adjasentSlots;
    }

    public void Build(Card card, WorldMap map)
    {
        
        var cardData = card.m_CardData;
        if( cardData.m_Building &&  cardData.m_Building.CanBuildBuilding(map))
        {
            DestroyBuilding();
            building = cardData.m_Building;
            Vector3 newPosition = transform.position + building.transform.position;
            var newRotation= building.transform.rotation * transform.rotation;
            building = Instantiate(building, newPosition, newRotation, transform);
            building.m_CardData = cardData;
            building.slot = this;
        }
    }
    
    public void DestroyBuilding()
    {
        if(building != null)
        {
            building.DestroyBuilding.Invoke();
            building.m_CardData = null;
            Destroy(building.gameObject);
            building = null;
        }
        animator.Play("BuildingSlotDestroy");
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
