using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardData", order = 1)]

[System.Serializable]
public class CardData : ScriptableObject
{
    public Color m_Color;
    [SerializeField] public string m_Description;
    [SerializeField] public string m_CardName;
    [SerializeField] public Sprite m_Sprite;
    [SerializeField] public Building m_Building;
    [SerializeField] public int m_Pollution;
    [SerializeField] public int m_Resources;
    [SerializeField] public int m_Cost;
}