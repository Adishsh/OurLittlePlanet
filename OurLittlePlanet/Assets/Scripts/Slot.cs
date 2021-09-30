using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public Card card;
    public Action OnSelectSlotCard;

    public void OnPointerClick (PointerEventData eventData)
    {
        OnSelectSlotCard();
    }
}
