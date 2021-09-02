using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] public CardData m_CardData;
    public bool m_isFrontUp { get; private set; }
    public bool m_isSelectable;

    private void Start() 
    {
        gameObject.GetComponent<Image>().sprite = m_CardData.m_texture;
    }

    public void MoveCardToNewSlot(GameObject newParent) 
    {
        gameObject.transform.SetParent(newParent.transform);
        transform.localPosition = Vector3.zero;
    }

    public void Flip(bool frontUp)
    {
        m_isFrontUp = frontUp;
    }

    public void SetUpCard()
    {

    }
}
