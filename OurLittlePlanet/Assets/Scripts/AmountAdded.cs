using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmountAdded : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;
    [SerializeField] private TMP_Text m_Polution;
    [SerializeField] private TMP_Text m_Resources;
    
    public void SetLocation(Transform worldTransform)
    {
        transform.position = worldTransform.position;
    }

    public void PlayAmountAdded(int polution, int resources,Camera cam, Transform worldTransform)
    {
        SetAmount(m_Polution, polution);
        SetAmount(m_Resources, resources);
        Vector3 screenPos = cam.WorldToScreenPoint(worldTransform.position);
        transform.position = screenPos;
        m_Animator.SetTrigger("Go");
    }

    private void SetAmount(TMP_Text text, int amount)
    {
        text.gameObject.SetActive(amount != 0);
        string sign = amount > 0 ? "+":"-";
        text.text = $"{sign}{amount.ToString()}";
    }
}
