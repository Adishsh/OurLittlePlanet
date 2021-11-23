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
        bool isActive = m_Instructions.activeSelf;
        HideSmallMenus();
        m_Instructions.SetActive(!isActive);
    }

    public void Credits(bool isOn)
    {
        bool isActive = m_Credits.activeSelf;
        HideSmallMenus();
        m_Credits.SetActive(!isActive);
    }

    public void SoundMenu(bool isOn)
    {
        bool isActive = m_SoundMenu.activeSelf;
        HideSmallMenus();
        m_SoundMenu.SetActive(!isActive);
    }

    public void ShowMenu(bool gameInProggress = true)
    {
        gameObject.SetActive(true);
        m_StartButton.SetActive(!gameInProggress);
        m_RestartButton.SetActive(gameInProggress);
        m_BackButton.SetActive(gameInProggress);
        HideSmallMenus();
    }

    private void HideSmallMenus()
    {
        m_Credits.SetActive(false);
        m_Instructions.SetActive(false);
        m_SoundMenu.SetActive(false);
    }

    public void HideMenu()
    {
        gameObject.SetActive(false);
    }

}
