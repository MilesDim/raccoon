using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class cabbage : MonoBehaviour
{
       
    private CabbageText  cabbageCounter;

    void Start() {
        // находим объект с скриптом CabbageCounter
        GameObject cabbageCounterObject = GameObject.Find("Canvas");
        // получаем ссылку на скрипт CabbageCounter
        cabbageCounter = cabbageCounterObject.GetComponent<CabbageText>();
    }

    void OnTriggerEnter(Collider other)
    {
       Debug.Log("OnTriggerEnter called"); 
        if (other.gameObject.CompareTag("Player"))
        {
            
            Destroy(gameObject);
            cabbageCounter.OnCabbageCollected();
        }
    }

    
}
