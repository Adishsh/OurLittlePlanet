using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_Cameras;
    [SerializeField] private TMP_Text m_CurrCameraText;

    private int currentCameraIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Key1"))
        {
            SwitchToCamera(0);
        }
        
        if (Input.GetButtonDown("Key2"))

        {
            SwitchToCamera(1);
        }
        
        if (Input.GetButtonDown("Key3"))

        {
            SwitchToCamera(2);
        }
        
        if (Input.GetButtonDown("Key4"))

        {
            SwitchToCamera(3);
        }
    }

    private void SwitchToCamera(int cameraIndex)
    {
        if(cameraIndex >= m_Cameras.Count)
        {
            return;
        }

        currentCameraIndex = cameraIndex;
        m_CurrCameraText.text = (currentCameraIndex + 1).ToString();
        for(int i =0; i< m_Cameras.Count; i++)
        {
            m_Cameras[i].SetActive(cameraIndex == i);
        }
    }

    public void MoveToNextCamera()
    {
        int nextCameraIndex = (currentCameraIndex + 1) % m_Cameras.Count;
        Debug.Log("nextCameraIndex+"+nextCameraIndex);
        SwitchToCamera(nextCameraIndex);
    }
}
