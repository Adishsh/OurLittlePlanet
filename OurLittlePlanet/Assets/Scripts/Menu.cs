using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject m_Instructions;
    [SerializeField] private GameObject m_Credits;
    [SerializeField] private GameObject m_SoundMenu;
    [SerializeField] private GameObject m_StartButton;
    [SerializeField] private GameObject m_RestartButton;
    [SerializeField] private GameObject m_BackButton;



    public void Instructions(bool isOn)
    {
        m_Instructions.SetActive(isOn);
    }

    public void Credits(bool isOn)
    {
        m_Credits.SetActive(isOn);

    }

    public void SoundMenu(bool isOn)
    {
        m_SoundMenu.SetActive(isOn);
    }

    public void ShowMenu(bool gameInProggress = true)
    {
        gameObject.SetActive(true);
        m_StartButton.SetActive(!gameInProggress);
        m_RestartButton.SetActive(gameInProggress);
        m_BackButton.SetActive(gameInProggress);
    }

    public void HideMenu()
    {
        gameObject.SetActive(false);
    }

}
