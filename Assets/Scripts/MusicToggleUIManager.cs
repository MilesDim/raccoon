using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicToggleUIManager : MonoBehaviour
{
public Toggle musicToggle;
public Image musicOnImage;
public Image musicOffImage;
public string musicTag = "Music"; // Тег для поиска объекта с компонентом BackgroundMusic

private void Start()
{
    // Устанавливаем начальное состояние Toggle на основе сохраненных данных
    bool isMusicEnabled = GetMusicEnabled();
    musicToggle.isOn = isMusicEnabled;

    // Обновляем UI в соответствии с состоянием музыки
    UpdateMusicUI(isMusicEnabled);
}

// Обработчик события при нажатии на Toggle
public void OnToggleClick()
{
    bool isMusicEnabled = musicToggle.isOn; // Получаем текущее состояние Toggle (включено или выключено)
    PlayerPrefs.SetInt("MusicEnabled", isMusicEnabled ? 1 : 0); // Сохраняем состояние музыки в PlayerPrefs
    PlayerPrefs.Save();

    // Включаем или выключаем музыку, вызывая методы у объекта с тегом "Music"
    GameObject musicObject = GameObject.FindWithTag(musicTag);
    if (musicObject != null)
    {
        BackgroundMusic backgroundMusic = musicObject.GetComponent<BackgroundMusic>();
        if (backgroundMusic != null)
        {
            if (isMusicEnabled)
            {
                backgroundMusic.PlayNextTrack();
            }
            else
            {
                backgroundMusic.StopMusic();
            }
        }
        else
        {
            Debug.LogError("BackgroundMusic component not found on object with tag: " + musicTag);
        }
    }
    else
    {
        Debug.LogError("Object with tag: " + musicTag + " not found in the scene!");
    }

    // Обновляем UI по состоянию музыки
    UpdateMusicUI(isMusicEnabled);
}

private void UpdateMusicUI(bool isMusicEnabled)
{
    // Показываем или скрываем картинку галочки и крестика в зависимости от состояния музыки
    musicOnImage.gameObject.SetActive(isMusicEnabled);
    musicOffImage.gameObject.SetActive(!isMusicEnabled);
}

private bool GetMusicEnabled()
{
    // Получаем состояние музыки из PlayerPrefs (0 - выключено, 1 - включено)
    int musicEnabled = PlayerPrefs.GetInt("MusicEnabled", 1);
    return musicEnabled == 1;
}
}
