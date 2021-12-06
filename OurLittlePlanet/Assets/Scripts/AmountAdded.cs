using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmountAdded : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;
    [SerializeField] private TMP_Text m_Polution;
    [SerializeField] private TMP_Text m_Resources;
    [SerializeField] private TMP_Text m_CardName;

    
    public void SetLocation(Transform worldTransform)
    {
        transform.position = worldTransform.position;
    }

    public void PlayAmountAdded( Transform worldTransform, int polution = 0, int resources = 0, string cardName = "", Camera cam = null)
    {
        if(cam == null)
        {
             cam = Camera.main;
        }
        SetAmount(m_Polution, polution);
        SetAmount(m_Resources, resources);
        if(!string.IsNullOrEmpty(cardName) && m_CardName != null)
        {
            m_CardName.text = cardName;
        }
        Vector3 screenPos = cam.WorldToScreenPoint(worldTransform.position);
        transform.position = screenPos;
        m_Animator.SetBool("Hide", false);
        m_Animator.SetTrigger("Go");
    }

    private void SetAmount(TMP_Text text, int amount)
    {
        text.gameObject.SetActive(amount != 0);
        string sign = amount > 0 ? "+":"";
        text.text = $"{sign}{amount.ToString()}";
    }

        public void Hide()
    {
        m_Animator.SetBool("Hide", true);
    }
}
