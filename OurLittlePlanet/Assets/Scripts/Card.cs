using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] TMP_Text m_CardName;
    [SerializeField] TMP_Text m_Description;
    [SerializeField] Text m_Cost;
    [SerializeField] Text m_Polution;
    [SerializeField] Text m_Population;
    [SerializeField] Image m_CardImage;

    public CardData m_CardData{ get; private set; }
    public bool m_isFrontUp { get; private set; }

    private void Start()
    {
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

        if( m_CardData.m_Sprite)
        {
            m_CardImage.sprite = m_CardData.m_Sprite;
        }
        Image image = gameObject.GetComponent<Image>();
        image.color = m_CardData.m_Color;
    }

}
