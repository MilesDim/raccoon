using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteHandler : MonoBehaviour
{
   private void Start()
    {
        // Определите имя текущей сцены
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Сохраняем имя текущей сцены при ее завершении
        LevelManager.SaveCurrentLevel(currentSceneName);
    }
}
