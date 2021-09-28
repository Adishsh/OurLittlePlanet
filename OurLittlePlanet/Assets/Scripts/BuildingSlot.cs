using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSlot : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] int index;
    public void Build(Card card)
    {
        cube.SetActive(true);
        cube.GetComponent<Renderer>().material.color = card.m_CardData.color;
    }
    
    public void DestroyBuilding()
    {
        cube.SetActive(true);
    }

    private void OnMouseUp()
    {
        GameManager.Instance.BuildCard(index);
    }
}
