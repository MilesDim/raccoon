using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    public static int Offset = 0;
    public void ChangeScene(int sceneIndex)
    {
         SceneManager.LoadScene("Level" + (sceneIndex + 1));
    }

    //  public void ChangeScene(int sceneIndex)
    // {
    //     int levelAt = PlayerPrefs.GetInt("levelAt", Offset);
    //     int actualSceneIndex = sceneIndex + Offset ;

    //     // Проверка, разблокирован ли уровень
    //     if (actualSceneIndex <= levelAt)
    //     {
    //         SceneManager.LoadScene(actualSceneIndex);
    //     }
    //     else
    //     {
    //         Debug.Log("Уровень заблокирован!");
    //     }
    // }

    public void QuitGame()
    {
        Application.Quit();
    }
}
