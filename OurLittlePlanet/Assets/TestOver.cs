using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isOver = false;
    public GameObject PopUpTest;

    private void Start()
    {
        PopUpTest.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse enter");
        isOver = true;
        PopUpTest.gameObject.SetActive(true);
        AudioManager.S.Play_Sound((AudioManager.SoundTypes.Hover_02));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exit");
        isOver = false;
        PopUpTest.gameObject.SetActive(false);
    }
    
}