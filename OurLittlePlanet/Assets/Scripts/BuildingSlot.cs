using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSlot : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] int index;
    public List<BuildingSlot> AdjasentSlots; 
    public CardData cardData;
    
    public void Build(Card card)
    {
        Debug.Log($"cardP ={card.m_CardData.m_Pollution}");
        cardData = card.m_CardData;
        cube.SetActive(true);
        cube.GetComponent<Renderer>().material.color = card.m_CardData.color;
    }
    
    public void DestroyBuilding()
    {
        cardData = null;
        cube.SetActive(true);
    }

    private void OnMouseUp()
    {
        GameManager.Instance.BuildCard(index);
    }
}
