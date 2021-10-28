using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup_Enter : MonoBehaviour
{

    public GameObject Popup_Window;
    // Start is called before the first frame update
    public void PlayPopup()
    {
        if (Popup_Window != null)
        { 
        Popup_Window.SetActive(true); 
        }
        else
        {
            Popup_Window.SetActive(false);   
        }
        Debug.Log("OK");
    }

}
