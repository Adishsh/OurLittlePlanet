using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardData : MonoBehaviour
{
    [SerializeField] public int m_polution;
    [SerializeField] public int m_energy;
    [SerializeField] public int m_price;
    [SerializeField] public Sprite m_texture;
    [SerializeField] public string m_description;
}
