using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public Card card;
    public Action OnSelectSlotCard;
    private bool m_isSelected;
    private Animator m_Animator;

    private void Awake() 
    {
          m_Animator = GetComponent<Animator>();  
    }
    
    public void OnPointerClick (PointerEventData eventData)
    {
        OnSelectSlotCard();
    }
    
    public void SetCard(Card newCard, bool moveCardLocation = true)
    {
        card = newCard;
        if(newCard != null && moveCardLocation)
        {
            newCard.MoveCardToSlot(this);
        }
    }

    public void SelectSlot(bool isSelected)
    {
        m_isSelected = isSelected;
        m_Animator.SetBool("glow", isSelected);
    }

}
