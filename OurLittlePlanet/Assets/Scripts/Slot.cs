using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] public Card card;

public void SelectSlot()
{
    Card newCard = GameManager.Instance.selectedCard;
    if(newCard != null && card == null)
    {
        card = newCard;
        card.MoveCardToNewSlot(this);
        GameManager.Instance.selectedCard = null;
    }
}


    // Update is called once per frame
    void Update()
    {
        
    }
}
