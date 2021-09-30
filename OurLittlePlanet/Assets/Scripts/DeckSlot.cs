using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSlot : Slot
{
    protected override void SelectSlotCard()
    {
        EventManager.instance.DrawCards.Invoke();
    }
}
