using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public void OnClicked()
    {
            Time.timeScale = 1;
      SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);

    }
}
