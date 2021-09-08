using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardData : MonoBehaviour
{
    [SerializeField] public int m_Pollution;
    [SerializeField] public int m_Resources;
    [SerializeField] public int m_Cost;
    [SerializeField] public Sprite m_Sprite;
    [SerializeField] public string m_Description;
    //[SerializeField] public string m_Name;
    [SerializeField] public GameObject m_Building;
}
