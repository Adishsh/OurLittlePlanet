using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textnext : MonoBehaviour
{

    public GameObject nextText;
    public GameObject previousText;
    
    public void OnMouseDown()
    {
        nextText.SetActive(true);
        previousText.SetActive(false);
        print("Click");
    }
}
