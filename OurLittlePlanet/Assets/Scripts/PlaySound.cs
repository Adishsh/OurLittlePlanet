using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public void Play1()
    {
        AudioManager.S.Play_Sound((AudioManager.SoundTypes.Hover_02));

    }
    
    public void Play2()
    {
        AudioManager.S.Play_Sound((AudioManager.SoundTypes.Gameplay));

    }
}
