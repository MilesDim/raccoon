using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using TMPro;

public class LanguageManager : MonoBehaviour
{
    
    public static LanguageManager instance;
    public Dictionary<string, TMP_FontAsset> languageFonts; 

    private int currentLanguageIndex = 0;
    public TMP_FontAsset font_en;
    
    List<TMP_Text> textObjects;
    private int score = 0;

    private void Awake()
    {
        languageFonts = new Dictionary<string, TMP_FontAsset>();
        languageFonts.Add("en", font_en);

        // Загрузите выбранный язык и установите его
        string selectedLanguage = LoadSelectedLanguage();
        ChangeLanguage(true); // Установите выбранный язык вперед
    }

    public void addTextObject(TMP_Text textObject){
        textObjects.Add(textObject);
    }

   public void ChangeLanguage(bool forward)
   {
    int languageCount = LocalizationSettings.AvailableLocales.Locales.Count;
    
    if (forward)
    {
        currentLanguageIndex = (currentLanguageIndex + 1) % languageCount;
    }
    else
    {
        currentLanguageIndex = (currentLanguageIndex - 1 + languageCount) % languageCount;
    }

    // Получите текущий выбранный язык и его код
    var selectedLanguage = LocalizationSettings.AvailableLocales.Locales[currentLanguageIndex];
    var selectedLanguageCode = selectedLanguage.Identifier.Code;

    // Сохраните выбранный язык
    SaveSelectedLanguage(selectedLanguageCode);

    // Примените шрифт для текущего языка
    ApplyFontForCurrentLanguage(selectedLanguageCode);
    }
    private void SaveSelectedLanguage(string languageCode)
    {
    PlayerPrefs.SetString("SelectedLanguage", languageCode);
    }

    private void ApplyFontForCurrentLanguage(string languageCode)
    {
        // Применяем шрифт для текущего языка, если он доступен
        if (languageFonts.TryGetValue(languageCode, out TMP_FontAsset font))
        {
            TMP_Text[] textElements = Resources.FindObjectsOfTypeAll(typeof(TMP_Text)) as TMP_Text[]; 
            foreach (TMP_Text textElement in textElements)
            {
                textElement.font = font; // Используем свойство font для установки шрифта
            } 
        }
    }


  private void ApplyFontForCurrentLanguage2(string languageCode)
    {
        // Применяем шрифт для текущего языка, если он доступен
        if (languageFonts.TryGetValue(languageCode, out TMP_FontAsset font))
        {
            // Обновляем шрифт для всех объектов TMP_Text
            TMP_Text[] tmpTextElements = FindObjectsOfType<TMP_Text>();
            foreach (TMP_Text textElement in tmpTextElements)
            {
                textElement.font = font; // Используем свойство font для установки шрифта
            }

            // Обновляем шрифт для всех объектов TMPro.TextMeshProUGUI
            TextMeshProUGUI[] textMeshProElements = FindObjectsOfType<TextMeshProUGUI>();
            foreach (TextMeshProUGUI textMeshProElement in textMeshProElements)
            {
                textMeshProElement.font = font; // Используем свойство font для установки шрифта
            }

        }
    }
    public void ChangeScore(bool forward)
    {
        if (forward)
        {
            score++;
        }
        else
        {
            score--;
        }

    }
    private string LoadSelectedLanguage()
    {
    return PlayerPrefs.GetString("SelectedLanguage", "en"); // "en" - язык по умолчанию
    }


}
