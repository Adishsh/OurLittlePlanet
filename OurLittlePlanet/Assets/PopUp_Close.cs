using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp_Close : MonoBehaviour
{

    public GameObject Popup_Window;
    public void OnMouseDown()
    {
        Popup_Window.SetActive(false);
    }

}