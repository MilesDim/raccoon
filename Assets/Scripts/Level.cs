using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{ 
   void Start()
{
    int levelAt = LevelManager.unlockedLevel;
    int i = 0;
    foreach (Transform child in transform)
    {
        Button btn = child.GetComponent<Button>();
        if (i > levelAt)
        {
            btn.interactable = false;
            btn.transform.GetChild(0).gameObject.SetActive(true); 
            btn.transform.GetChild(1).gameObject.SetActive(false);
        } 
        else
        {
            btn.interactable = true;
            btn.transform.GetChild(0).gameObject.SetActive(false); 
            btn.transform.GetChild(1).gameObject.SetActive(true); 
            int levelIndex = i;
            btn.onClick.AddListener(() => LoadLevel(levelIndex));
        }
        i++;
    }
}

private void LoadLevel(int levelIndex)
{
    SceneManager.LoadScene("Level" + (levelIndex + 1));
}
} 

    