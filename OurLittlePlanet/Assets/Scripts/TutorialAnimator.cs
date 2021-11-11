using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAnimator : MonoBehaviour
{
    private Animator m_Animator;
    // Start is called before the first frame update
    private void Awake() {
        m_Animator = GetComponent<Animator>();
        
    }

    public void StartAnimation()
    {
        m_Animator.SetTrigger("Start");
    }

    public void OnClick()
    {
        m_Animator.SetTrigger("Clicked");
    }
}
