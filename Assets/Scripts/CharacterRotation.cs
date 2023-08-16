using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    public float autoRotationSpeed = 50.0f; // Скорость автоматического вращения персонажа
    public float manualRotationSpeed = 100.0f; 

    private bool isRotatingManually = false; // Флаг для определения, вращается ли персонаж вручную
    private Vector3 lastMousePosition; // Последняя позиция мыши

    private void Update()
    {
        // Автоматическое вращение
        float autoRotationAmount = autoRotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, autoRotationAmount);

        // Вращение при удержании кнопки мыши
        if (Input.GetMouseButtonDown(0))
        {
            isRotatingManually = true;
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            isRotatingManually = false;
        }

        if (isRotatingManually) 
        {
            // Вычисляем изменение позиции мыши
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
            float manualRotationAmount = manualRotationSpeed * Time.deltaTime * mouseDelta.x;
            transform.Rotate(Vector3.up, manualRotationAmount);

            // Обновляем последнюю позицию мыши
            lastMousePosition = Input.mousePosition;
        }
    }
}
