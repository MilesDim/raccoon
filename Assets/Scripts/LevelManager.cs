using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
  public static int unlockedLevel = 0;

    public static void SaveCurrentLevel(string sceneName)
    {
        PlayerPrefs.SetString("CurrentLevel", sceneName);
        PlayerPrefs.Save();
        unlockedLevel = GetLevelIndexFromName(sceneName);
        Debug.Log("Saved current level: " + sceneName);
    }

    public static string LoadCurrentLevel()
    {
        return PlayerPrefs.GetString("CurrentLevel", "Level1");
    }

    private static int GetLevelIndexFromName(string sceneName)
{
    
    string levelNumberString = sceneName.Remove(0, 5);
    return int.Parse(levelNumberString) - 1;
}
}

