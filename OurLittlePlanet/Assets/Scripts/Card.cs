using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] Text m_CardName;
    [SerializeField] Text m_Description;
    [SerializeField] Text m_Cost;
    [SerializeField] Text m_Polution;
    [SerializeField] Text m_Population;

    public CardData m_CardData{ get; private set; }
    public bool m_isFrontUp { get; private set; }

    private void Start()
    {
        //gameObject.GetComponent<Image>().sprite = m_CardData.m_Sprite;
        //gameObject.GetComponent<Image>().color = m_CardData.m_Color;
        var parent =  gameObject.transform.parent;
    }

    public void MoveCardToSlot(Slot newParent)
    {
        gameObject.transform.SetParent(newParent.transform);
        transform.localPosition = Vector3.zero;
    }

    public void Flip(bool frontUp)
    {
        m_isFrontUp = frontUp;
    }

    public void SetUpCard(CardData cardData)
    {
        m_CardData = cardData;
        m_CardName.text = cardData.m_CardName;
        m_Description.text = cardData.m_Description;
        m_Cost.text = cardData.m_Cost.ToString();
        m_Polution.text = cardData.m_Pollution.ToString();
        m_Population.text = cardData.m_Resources.ToString();

        Image image = gameObject.GetComponent<Image>();
        if( m_CardData.m_Sprite)
        {
            image.sprite = m_CardData.m_Sprite;
        }
        image.color = m_CardData.m_Color;
    }
}
