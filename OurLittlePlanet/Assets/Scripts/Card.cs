using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] public CardData m_CardData;
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

        Image image = gameObject.GetComponent<Image>();
        if( m_CardData.m_Sprite)
        {
            image.sprite = m_CardData.m_Sprite;
        }
        image.color = m_CardData.m_Color;
    }
}
