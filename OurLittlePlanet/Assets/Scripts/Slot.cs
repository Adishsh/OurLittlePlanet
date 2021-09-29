using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] public Card card;

    public virtual void SelectSlotCard()
    {
    }
}
