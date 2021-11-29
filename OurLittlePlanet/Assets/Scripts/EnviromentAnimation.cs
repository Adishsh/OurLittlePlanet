using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentAnimation : MonoBehaviour
{
    [SerializeField] List<int> polutionAnimationStages;

    private Animator m_Animator;
    private int currentPolutionStage;
    private bool IsInLastPolutionStage => currentPolutionStage >= polutionAnimationStages.Count;
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void SetPolution(int polution)
    {
        while (!IsInLastPolutionStage && polution >= polutionAnimationStages[currentPolutionStage])
        {
            currentPolutionStage++;
        }
        m_Animator.SetInteger("PolutionState", currentPolutionStage);
    }
}
