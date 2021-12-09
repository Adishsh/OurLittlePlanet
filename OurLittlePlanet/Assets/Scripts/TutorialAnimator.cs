using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAnimator : MonoBehaviour
{
    Action m_Oncomplete;
    private Animator m_Animator;
    // Start is called before the first frame update
    private void Start() {
        m_Animator = GetComponent<Animator>();
    }

    public void StartAnimation(Action oncomplete)
    {
        if(m_Animator == null)
        {
            m_Animator = GetComponent<Animator>();
        }
        m_Animator?.SetTrigger("Start");
        m_Oncomplete = oncomplete;
    }

    public void OnClick()
    {
        m_Animator?.SetTrigger("Clicked");
    }

    
    public void OnEraEnd()
    {
        m_Oncomplete?.Invoke();
        m_Oncomplete = null;
    }
}
