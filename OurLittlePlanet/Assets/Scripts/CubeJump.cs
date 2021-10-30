using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJump : MonoBehaviour
{
    [SerializeField]
    BeatManager2 BeatManagerRef;



    public Vector3 JumpForce;

    Rigidbody RB;

    public float DelayTime;


    public bool IsRegisterToBeat;
    public bool IsDoJump;

    private void OnValidate()
    {
        if (IsDoJump)
        {
            IsDoJump = false;

            Jump();
        }
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody>();

        if (IsRegisterToBeat)
        {
            BeatManagerRef.OnBeat += WhenBeat;
        }   
    }

    private void WhenBeat(int beatCount)
    {
        Jump();
    }

    void Jump()
    {
        StartCoroutine(JumpCoroutine());
    }

    IEnumerator JumpCoroutine()
    {
        yield return StartCoroutine(BeatManagerRef.WaitForBeat_Coroutine());

      //  yield return new WaitForSeconds(DelayTime);
        RB.AddForce(JumpForce, ForceMode.Impulse);
    }
}
