using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Board Board;
    public Card selectedCard;

    private void Awake() 
    {
        Instance = this;
    }
        
    private void SetUpGame()
    {

    }
    
    private void ActivateEvent()
    {

    }

    public void SelectCard(Card card)
    {
        if(selectedCard != null)
        {
            selectedCard.UnselectCard();
        }
        selectedCard = card;
    }


}
