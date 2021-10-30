using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager2 : MonoBehaviour
{
    public bool IsDoBeat;
    public float BPM = 120;

    public float OffsetOfTrack; 

    public AudioSource AudioSourceRef;

    public int BeatCount = 0;


    private float CurrentTime;


    public Action<int> OnBeat;

    private void Start()
    {
        StartCoroutine(BeatCoroutine());
    }

    IEnumerator BeatCoroutine()
    {
        while (IsDoBeat)
        {

            CurrentTime = AudioSourceRef.time;

            if (CurrentTime > (60f / BPM) * BeatCount - OffsetOfTrack)
            {
                BeatCount++;

                if (OnBeat != null)
                {
                    OnBeat(BeatCount);
                }

            }

            yield return null;
        }
    }

    public IEnumerator WaitForBeat_Coroutine()
    {

        bool isBeat = false;
        OnBeat += WaitForBeat;

        while (!isBeat)
        {
            yield return null;
        }

       // END OF FUNCTION


        //*****
        void WaitForBeat(int beatCount)
        {
            isBeat = true;
            OnBeat -= WaitForBeat;

        }
        //****
    }
}
