using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] TMP_Text m_CardName;
    [SerializeField] TMP_Text m_Description;
    [SerializeField] TMP_Text m_DescriptionUp;
    [SerializeField] TMP_Text m_Cost;
    [SerializeField] TMP_Text m_Polution;
    [SerializeField] TMP_Text m_Population;
    [SerializeField] Image m_CardImage;
    [SerializeField] GameObject m_tooltipLeft;
    [SerializeField] GameObject m_tooltipUp;

    public CardData m_CardData{ get; private set; }
    public bool m_isFrontUp { get; private set; }
    public bool m_TooltipDiractionUp;

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
        m_DescriptionUp.text = cardData.m_Description;
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        var tooltip = m_TooltipDiractionUp ? m_tooltipUp : m_tooltipLeft;
        if(!string.IsNullOrEmpty(m_CardData.m_Description))
         tooltip.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_tooltipLeft.SetActive(false);
        m_tooltipUp.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_tooltipLeft.SetActive(false);
        m_tooltipUp.SetActive(false);
    }
}
