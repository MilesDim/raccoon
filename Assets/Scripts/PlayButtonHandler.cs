using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonHandler : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        // Загружаем имя текущей сцены из сохраненных данных
        string currentSceneName = LevelManager.LoadCurrentLevel();

        // Загружаем соответствующую сцену по ее имени
        SceneManager.LoadScene(currentSceneName);
        Debug.Log("LOL");
    }
}
