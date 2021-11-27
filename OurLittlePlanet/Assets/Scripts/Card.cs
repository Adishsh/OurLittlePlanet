using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
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
    [SerializeField] Animator m_Animator;

    public CardData m_CardData { get; private set; }
    public bool m_isFrontUp { get; private set; }
    public bool m_TooltipDiractionUp;
     public float speed = 2f;
     public bool allowDrag;
 
     private Vector3 start;
     private Vector3 des;
     private float fraction = 0; 

    private void Start()
    {
        des = Vector3.zero;
        var parent = gameObject.transform.parent;
    }

    private void Update() 
    {
         if (fraction < 1) {
             fraction += Time.deltaTime * speed;
             transform.localPosition = Vector3.Lerp(start, des, fraction);
             if(m_tooltipUp.activeSelf)
             m_tooltipUp.SetActive(false);
             if(m_tooltipLeft.activeSelf)
             m_tooltipLeft.SetActive(false);
         }
    }

    public void MoveCardToSlot(Slot newParent)
    {
        m_Animator?.SetBool("Glow", false);
        gameObject.transform.SetParent(newParent.transform);
        start = transform.localPosition;
        fraction = 0;
    }

    public void Flip(bool frontUp)
    {
        m_isFrontUp = frontUp;
        m_Animator.SetBool("Flip", !frontUp);
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

        if (m_CardData.m_Sprite)
        {
            m_CardImage.sprite = m_CardData.m_Sprite;
        }
        Image image = gameObject.GetComponent<Image>();
        image.color = m_CardData.m_Color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        var tooltip = m_TooltipDiractionUp ? m_tooltipUp : m_tooltipLeft;
        if (!string.IsNullOrEmpty(m_CardData.m_Description))
            tooltip.SetActive(true);
        AudioManager.S.Play_Sound((AudioManager.SoundTypes.Hover_01));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_tooltipLeft.SetActive(false);
        m_tooltipUp.SetActive(false);
    }
   
    public void OnPointerDown(PointerEventData eventData)
    {
        var tooltip = m_TooltipDiractionUp ? m_tooltipUp : m_tooltipLeft;
        var otherTooltip = !m_TooltipDiractionUp ? m_tooltipUp : m_tooltipLeft;
     
        tooltip.SetActive(!tooltip.activeSelf && !string.IsNullOrEmpty(m_CardData.m_Description));

        otherTooltip.SetActive(false);
    }
    
    public void selectCard(bool isSelected)
    {
        m_Animator?.SetBool("Glow", isSelected);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!allowDrag)
        {
            return;
        }
        StatsManager.Instance.CardIsDragged = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!allowDrag)
        {
            return;
        }
        transform.position = Input.mousePosition;
        m_tooltipLeft.SetActive(false);
        m_tooltipUp.SetActive(false);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(!allowDrag)
        {
            return;
        }
        StatsManager.Instance.CardIsDragged = false;
        if(StatsManager.Instance.buildingSlotSelected!= null)
        {
            EventManager.instance.BuildCard.Invoke(StatsManager.Instance.buildingSlotSelected.index);
        }else
        {

        start = transform.localPosition;
        fraction = 0;
        }
    }
}
