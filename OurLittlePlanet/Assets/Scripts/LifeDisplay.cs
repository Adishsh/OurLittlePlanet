using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour
{
    [SerializeField] List<RawImage> m_Hearts;
    [SerializeField] Color m_Fade;

    public void SetLife(int lifeCount)
    {
            for(int i =0 ; i < m_Hearts.Count; i++)
            {
                Debug.Log("strikes " + lifeCount);
                m_Hearts[i].color = i < lifeCount ? Color.white: m_Fade;
            }
    }
}
