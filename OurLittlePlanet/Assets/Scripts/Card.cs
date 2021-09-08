using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] public CardData m_CardData;
    public bool m_isFrontUp { get; private set; }
    public bool m_isSelectable;
    public bool m_isSelected;
    private Slot slot;

    private void Start()
    {
        gameObject.GetComponent<Image>().sprite = m_CardData.m_Sprite;
        var parent =  gameObject.transform.parent;
        slot = parent.GetComponent<Slot>();
    }

    public void MoveCardToNewSlot(Slot newParent)
    {
        if(slot != null)
        {
            slot.card = null;
        }
        gameObject.transform.SetParent(newParent.transform);
        transform.localPosition = Vector3.zero;
        slot = newParent;
    }

    public void SelectCard()
    {
        GameManager.Instance.SelectCard(this);
        m_isSelected = true;
    }

    public void UnselectCard()
    {
        m_isSelected = false;
    }

    public void Flip(bool frontUp)
    {
        m_isFrontUp = frontUp;
    }

    public void SetUpCard()
    {

    }
}
