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

        Music_Background3 = 1,
        Music_Background= 2,
        Music_Background2 = 3,
        Atmosphere = 4,
        Atmosphere2 = 5,
        Atmosphere3 = 6,
        Atmosphere4 = 7,
        Gameplay = 8,
        Sunny = 9,
        Rainy = 10,
        Stormy = 11,
        Heatwave = 12,
        Tornado = 13,
        Tsunami = 14,
        Meteor = 15,
        
        
        
        
        
        // UI_Sounds
        Click_01 = 100,
        Click_02 = 101,
        Hover_01 = 102,
        Hover_02 = 103,
        Cards_Shuffle = 104,
        Construction = 105,
        Bad_Event = 106,
        Camera = 107,
        // Gameplay Sounds
        Buycard =200,
        Shrink = 201,
        PopUpOpen = 202,
        FailiBuycard =203,
        EraChange =204,
        Lose =205,
        Lose2 =206,
        Win =207,

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
        if(source == null || clip == null)
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
        return Get_SoundType_And_Ref_By(soundType)?.AudioSourceRef;
    }

    private AudioClip Get_AudioClip_Of(SoundTypes soundType)
    {
        return Get_SoundType_And_Ref_By(soundType)?.AudioClipRef;
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
