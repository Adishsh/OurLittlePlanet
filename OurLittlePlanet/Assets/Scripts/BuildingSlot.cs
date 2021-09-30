using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSlot : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] int index;
    public List<BuildingSlot> m_AdjasentSlots {get; private set;} 
    public CardData m_CardData {get; private set;}
    
    public BuildingSlot(List<BuildingSlot> adjasentSlots)
    {
        m_AdjasentSlots = adjasentSlots;
    }
    public void Build(Card card)
    {
        Debug.Log($"cardP ={card.m_CardData.m_Pollution}");
        m_CardData = card.m_CardData;
        cube.SetActive(true);
        cube.GetComponent<Renderer>().material.color = card.m_CardData.m_Color;
    }
    
    public void DestroyBuilding()
    {
        m_CardData = null;
        cube.SetActive(true);
    }

    private void OnMouseUp()
    {
        EventManager.instance.BuildCard.Invoke(index);
    }
}
