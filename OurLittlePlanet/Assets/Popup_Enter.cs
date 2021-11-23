using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup_Enter : MonoBehaviour
{

    public GameObject Popup_Window;
    // Start is called before the first frame update
    public void PlayPopup()
    {
        Popup_Window.SetActive(true);
        AudioManager.S.Play_Sound((AudioManager.SoundTypes.Hover_02));
    }

    
    /*
    if (Popup_Window != null)
    { 
        Popup_Window.SetActive(true); 
        Debug.Log("OK");
    }
*/

}
