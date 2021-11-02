using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PopUp_Open : MonoBehaviour , IPointerDownHandler
{

    public GameObject PopUp_Window;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        PopUp_Window.SetActive(true);
        Debug.Log("OK_OPEN");
    }
    /*
    public GameObject Popup_Window;
    
    
    public void OnMouseOver()
    {
        // Destroy the gameObject after clicking on it
        Destroy(gameObject);
        Debug.Log("WOOO");
    }

   
    public void OnMouseDown()
    {
        Popup_Window.SetActive(true);
        Debug.Log("YEAH");
    }
*/
    
}