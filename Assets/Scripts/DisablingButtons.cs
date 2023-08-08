using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisablingButtons : MonoBehaviour
{
    [SerializeField] private GameObject prefabInstance;
    private bool isPrefabActive = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (prefabInstance != null)
            {
                isPrefabActive = !isPrefabActive; // Инвертируем состояние активности
                prefabInstance.SetActive(isPrefabActive); // Включаем/отключаем префаб
            }
        }
    }
}

