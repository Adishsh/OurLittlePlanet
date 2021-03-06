using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour
{
    [SerializeField] List<RawImage> m_Hearts;
    [SerializeField] Color m_Fade;
    int oldLifeCount;
    public void SetLife(int lifeCount)
    {
        int change = lifeCount - oldLifeCount;
        if(change == 1)
        {
            m_Hearts[lifeCount -1].gameObject.GetComponent<Animator>().SetTrigger("Shine");
            

        }
        if(change == -1)
        {
            m_Hearts[lifeCount].gameObject.GetComponent<Animator>().SetTrigger("Shine");
            AudioManager.S.Play_Sound((AudioManager.SoundTypes.Shrink));
        }
            for(int i =0 ; i < m_Hearts.Count; i++)
            {
                Debug.Log("strikes " + lifeCount);
                m_Hearts[i].color = i < lifeCount ? Color.white: m_Fade;
            }
            oldLifeCount = lifeCount;

            if (lifeCount == 1)
            {
                AudioManager.S.Play_Sound((AudioManager.SoundTypes.Music_Background3));
            }
            
            if (lifeCount == 2)
            {
                AudioManager.S.Play_Sound((AudioManager.SoundTypes.Music_Background2));
            }
    }
}
