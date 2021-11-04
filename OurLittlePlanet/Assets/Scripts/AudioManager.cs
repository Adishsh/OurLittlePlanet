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
        public AudioSourceTypes AudioSourceType;
    }

    [Serializable]
    public class SoundSource_And_Ref
    {
        public AudioSourceTypes SourceType;
        public AudioSource AudioSourceRef;
    }


    [SerializeField]
    private List<SoundType_And_Ref> SoundType_And_Ref_List = new List<SoundType_And_Ref>();

    [SerializeField]
    private List<SoundSource_And_Ref> SoundSource_And_Ref_List = new List<SoundSource_And_Ref>();


    public enum SoundTypes
    {
        None = 0,

        ______Player_Sounds____ = 1,
        Music_Background= 2,
        GamePlay = 3,
        Atmosphere = 4,
        PowerUp = 5,
        // UI_Sounds
        Click_01 = 100,

        // Gameplay Sounds
        Bump =200,
        Shrink = 201,
        PopUpOpen = 202,


    }

    public enum AudioSourceTypes
    {
        None,
        UI,
        Player,
        Gameplay,
        Music,
        Atmosphere
    }

    internal void Init(GameManager gameManager)
    {
        
    }

    public void Play_Sound(SoundTypes soundType)
    {
        AudioClip clip = Get_AudioClip_Of(soundType);
        AudioSourceTypes audioSourceType = Get_AudioSourceType_Of(soundType);
        AudioSource source = Get_AudioSource_By_Type(audioSourceType);

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


    private AudioSource Get_AudioSource_By_Type(AudioSourceTypes audioSourceType)
    {
        for (int i = 0; i < SoundSource_And_Ref_List.Count; i++)
        {
            if (SoundSource_And_Ref_List[i].SourceType == audioSourceType)
            {
                return SoundSource_And_Ref_List[i].AudioSourceRef;
            }
        }

        return null;
    }

    private AudioClip Get_AudioClip_Of(SoundTypes soundType)
    {
        for (int i = 0; i < SoundType_And_Ref_List.Count; i++)
        {
            if (SoundType_And_Ref_List[i].SoundType == soundType)
                return SoundType_And_Ref_List[i].AudioClipRef;
        }

        return null;
    }
    
    private AudioSourceTypes Get_AudioSourceType_Of(SoundTypes soundType)
    {
        for (int i = 0; i < SoundType_And_Ref_List.Count; i++)
        {
            if (SoundType_And_Ref_List[i].SoundType == soundType)
                return SoundType_And_Ref_List[i].AudioSourceType;
        }

        return AudioSourceTypes.None;
    }
    

}
