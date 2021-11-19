using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialShowInOrder : MonoBehaviour
{
   [SerializeField] List<GameObject> m_ObjectsToShow;
   [SerializeField] GameObject m_Background;
   [SerializeField] string m_AnimatorsBoolText;

   private int index;

   public void StartTutorial()
   {
       ShowAndAnimate(m_Background, true);
       ShowAndAnimate(m_ObjectsToShow[0], true);
   }

   public void EndTutorial()
   {
       if (index < m_ObjectsToShow.Count)
       {
           ShowAndAnimate(m_ObjectsToShow[index], false);
       }
       ShowAndAnimate(m_Background, false);
       index= 0;
   }

    public void ShowNextObject()
   {
       ShowAndAnimate(m_ObjectsToShow[index], false);
       index++;
       if (index < m_ObjectsToShow.Count)
       {
           ShowAndAnimate(m_ObjectsToShow[index], true);
       }
       else
       {
           EndTutorial();
       }
   }

       public void ShowPrevObject()
   {
       if(index == 0)
       return;
        
       if (index < m_ObjectsToShow.Count)
       ShowAndAnimate(m_ObjectsToShow[index], false);
       index--;
       ShowAndAnimate(m_ObjectsToShow[index], true);
   }

   private void ShowAndAnimate(GameObject go, bool show)
   {
       Animator animator = go.GetComponent<Animator>();
       go.SetActive(show);

       if(animator == null)
       {
           go.SetActive(show);
       }
       else
       {
           animator.SetBool(m_AnimatorsBoolText, show);
       }
   }

}
