using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] public Card card;

public void CallCard()
{
    card.MoveCardToNewSlot(gameObject);
}


    // Update is called once per frame
    void Update()
    {
        
    }
}
