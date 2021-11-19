using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager S;

    private void Awake()
    {
        S = this;
    }

    [Serializable]
    public class SoundType_And_Ref
    {
        public SoundTypes SoundType;
        public AudioClip AudioClipRef;
       
        public AudioSource AudioSourceRef;
    }

  
    [SerializeField]
    private List<SoundType_And_Ref> SoundType_And_Ref_List = new List<SoundType_And_Ref>();

   

    public enum SoundTypes
    {
        None = 0,

        ______Player_Sounds____ = 1,
        Music_Background= 2,
        GamePlay = 3,
        Atmosphere = 4,
        PowerUp = 5,
        Music_02 = 6,
        
        
        
        
        
        
        // UI_Sounds
        Click_01 = 100,
        Tutorial_PopUp_01 = 101,
        // Gameplay Sounds
        Bump =200,
        Shrink = 201,
        PopUpOpen = 202,


    }

   

    internal void Init(GameManager gameManager)
    {
        
    }

    public void Play_Sound(SoundTypes soundType)
    {
        AudioClip clip = Get_AudioClip_Of(soundType);
        AudioSource source =Get_AudioSource_Of(soundType);

        Play_Sound(clip, source);

    }

    private void Play_Sound(AudioClip clip, AudioSource source)
    {
        if(source == null)
        {
            return;
        }
        source.clip = clip;
        source.Play();
    }


  


    private SoundType_And_Ref Get_SoundType_And_Ref_By(SoundTypes soundType)
    {
        for (int i = 0; i < SoundType_And_Ref_List.Count; i++)
        {
            if (SoundType_And_Ref_List[i].SoundType == soundType)
                return SoundType_And_Ref_List[i];
        }

        return null;
    }

    private AudioSource Get_AudioSource_Of(SoundTypes soundType)
    {
        return Get_SoundType_And_Ref_By(soundType).AudioSourceRef;
    }

    private AudioClip Get_AudioClip_Of(SoundTypes soundType)
    {
        return Get_SoundType_And_Ref_By(soundType).AudioClipRef;
        for (int i = 0; i < SoundType_And_Ref_List.Count; i++)
        {
            if (SoundType_And_Ref_List[i].SoundType == soundType)
                return SoundType_And_Ref_List[i].AudioClipRef;
        }

        return null;
    }
    
    public void MuteAudio(bool isOn)
    {
         for (int i = 0; i < SoundType_And_Ref_List.Count; i++)
        {
           SoundType_And_Ref_List[i].AudioSourceRef.mute =isOn;
        }

    }

    public void SetVolume(float volume)
    {
        for (int i = 0; i < SoundType_And_Ref_List.Count; i++)
        {
           SoundType_And_Ref_List[i].AudioSourceRef.volume = volume;
        }
    }

    public float GetVolume()
    {
        return SoundType_And_Ref_List[0].AudioSourceRef.volume;
    }

}
