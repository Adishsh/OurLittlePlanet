using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SoundMenu : MonoBehaviour
{
    [SerializeField] private AudioManager audiomanager;
    [SerializeField] private Slider m_Slider;
    [SerializeField] private TMP_Text OnOffText;


    bool isMuted = false;
    private void Start()
    {
        m_Slider.SetValueWithoutNotify( audiomanager.GetVolume());
        OnOffText.text = "Mute";

    }

    public void ChangeVolume()
    {
        audiomanager.SetVolume(m_Slider.value);
    }

    
    public void MuteToggle()
    {
        isMuted = !isMuted;
        audiomanager.MuteAudio(isMuted);
        OnOffText.text = isMuted ? "Turn On":"Mute";
    }
}
