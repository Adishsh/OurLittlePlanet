using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSlot : Slot
{
   public override void SelectSlotCard()
{
    if(card != null)
    {
        card.SelectCard();
        GameManager.Instance.selectedCard = card;
    }
}
}
