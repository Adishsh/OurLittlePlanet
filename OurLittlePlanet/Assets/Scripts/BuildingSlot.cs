using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSlot : MonoBehaviour
{

    [SerializeField] int index;
    public List<BuildingSlot> m_AdjasentSlots {get; private set;} 
    public CardData m_CardData {get; private set;}
    private Building building;

    public BuildingSlot(List<BuildingSlot> adjasentSlots)
    {
        m_AdjasentSlots = adjasentSlots;
    }
    public void Build(Card card)
    {
        DestroyBuilding();
        Debug.Log($"cardP ={card.m_CardData.m_Pollution}");
        m_CardData = card.m_CardData;
        building = m_CardData.m_Building;
        if(building)
        {
            Vector3 newPosition = transform.position + building.transform.position;
            building = Instantiate(building, newPosition, transform.rotation, transform);
            building.GetComponent<Renderer>().material.color = card.m_CardData.m_Color;
        }
    }
    
    public void DestroyBuilding()
    {
        if(building != null)
        {
            m_CardData = null;
            Destroy(building.gameObject);
            building = null;
        }
    }

    private void OnMouseUp()
    {
        EventManager.instance.BuildCard.Invoke(index);
    }
}
