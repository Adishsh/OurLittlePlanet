using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAnimator : MonoBehaviour
{
    private Animator m_Animator;
    // Start is called before the first frame update
    private void Start() {
        m_Animator = GetComponent<Animator>();
    }

    public void StartAnimation()
    {
        if(m_Animator == null)
        {
            m_Animator = GetComponent<Animator>();
        }
        m_Animator?.SetTrigger("Start");
    }

    public void OnClick()
    {
        m_Animator?.SetTrigger("Clicked");
    }
}
