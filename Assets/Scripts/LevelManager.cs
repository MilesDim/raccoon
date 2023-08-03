using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
     // В этом метод будем использовать PlayerPrefs для хранения имени текущей сцены
    public static void SaveCurrentLevel(string sceneName)
    {
        PlayerPrefs.SetString("CurrentLevel", sceneName);
        PlayerPrefs.Save();
    }

    // Метод для загрузки имени текущей сцены
    public static string LoadCurrentLevel()
    {
        return PlayerPrefs.GetString("CurrentLevel", "Level1"); // Возвращаем "Level1", если "CurrentLevel" не был найден
    }
}

