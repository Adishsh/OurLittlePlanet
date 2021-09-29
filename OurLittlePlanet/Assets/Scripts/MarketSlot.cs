using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketSlot : Slot
{
    public override void SelectSlotCard()
    {
        GameManager.Instance.BuyCard(card);
    }
}
