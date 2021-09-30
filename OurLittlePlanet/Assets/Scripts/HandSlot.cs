using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSlot : Slot
{
   protected override void SelectSlotCard()
{
    if(card != null)
    {
        card.SelectCard();
        EventManager.instance.SelectCard.Invoke(card);

    }
}
}
