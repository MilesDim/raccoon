using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{ 
    void Start()
    { 
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);
        int i = 0;
        foreach (Transform child in transform)
        {
            Button btn = child.GetComponent<Button>();
            if (i + 2 > levelAt){
                btn.interactable = false;
                btn.transform.GetChild(1).gameObject.SetActive(true);
                btn.transform.GetChild(2).gameObject.SetActive(false);
            }else{
                btn.transform.GetChild(1).gameObject.SetActive(false);
                btn.transform.GetChild(2).gameObject.SetActive(true);
            }
            i++;
        }
    }

   
}
