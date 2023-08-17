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
    private int score = 0;
    private const string LanguageSelectionKey = "LanguageSelection";

    public Button forwardButton; 
    public Button backButton;    

    private void Start()
    {
        forwardButton.onClick.AddListener(OnForwardButtonClick);
        backButton.onClick.AddListener(OnBackButtonClick);
    }

     private void Awake()
    {
        languageFonts = new Dictionary<string, TMP_FontAsset>();
        languageFonts.Add("en", font_en);

        // Загрузите выбранный язык и установите его
        string selectedLanguage = LoadSelectedLanguage();
        // ChangeLanguage(true); // Установите выбранный язык вперед

        // Примените шрифт для текущего языка после загрузки
        // ApplyFontForCurrentLanguage(selectedLanguage);
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
 
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[currentLanguageIndex];
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
        string loadedLanguage = PlayerPrefs.GetString(LanguageSelectionKey, "en");
        Debug.Log("!! loadedLanguage = "+loadedLanguage);
        return loadedLanguage;
    }
     public void OnForwardButtonClick()
    {
        ChangeLanguage(true); // Переключаемся на следующий язык
        Debug.Log("OnForwardButtonClick");
    }

    public void OnBackButtonClick()
    {
        ChangeLanguage(false); // Переключаемся на предыдущий язык
        Debug.Log("OnBackButtonClick");
    }
}