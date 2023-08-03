using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    public void ChangeScene(int sceneIndex)
    {
        Debug.Log(sceneIndex + 2);
        SceneManager.LoadScene(sceneIndex + 2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
