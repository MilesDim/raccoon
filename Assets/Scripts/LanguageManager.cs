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

    private void Awake()
    {
        languageFonts = new Dictionary<string, TMP_FontAsset>();
      
        languageFonts.Add("en", font_en);
    
        ChangeLanguage(true);
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

        // Получаем текущий выбранный язык и его код
        var selectedLanguage = LocalizationSettings.AvailableLocales.Locales[currentLanguageIndex];
        var selectedLanguageCode = selectedLanguage.Identifier.Code;
        LocalizationSettings.SelectedLocale = selectedLanguage;

        // Применяем шрифт для текущего языка
        ApplyFontForCurrentLanguage(selectedLanguageCode);
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

    // GameObject GetItemGameObject(Item item)
    // {
    //     Item[] items = Resources.FindObjectsOfTypeAll(typeof(Item)) as Item[];
    
    //     GameObject itemObj = null;
    
    //     foreach (var i in items)
    //     {
    //         if (i.universalID == item.universalID)
    //         {
    //             itemObj = i.gameObject;
    //             break;
    //         }
    //     }
    
    //     return itemObj;
    // }

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

            // Обновляем шрифт для всех объектов UnityEngine.UI.Text (если они используют TMPro.TMP_FontAsset)
            // Text[] uiTextElements = FindObjectsOfType<Text>();
            // foreach (Text uiTextElement in uiTextElements)
            // {
            //     // Если текстовый элемент не использует TMPro, применяем шрифт только если он UnityEngine.Font
            //     if (uiTextElement.GetComponent<TextMeshProUGUI>() == null)
            //     {
            //         if (uiTextElement.font != null && uiTextElement.font.GetType() == typeof(Font))
            //         {
            //             // Создаем новый компонент TMPro.TMP_FontAsset из существующего шрифта UnityEngine.Font
            //             TMP_FontAsset newFont = TMP_FontAsset.CreateFontAsset(uiTextElement.font);
            //             if (newFont != null)
            //             {
            //                 // Устанавливаем шрифт для текстового элемента
            //                 uiTextElement.font = newFont;
            //             }
            //         }
            //     }
            //     // // Проверяем, использует ли UI Text TMP_FontAsset
            //     // // if (uiTextElement.font is TMPro.TMP_FontAsset tmpFont)
            //     // if (uiTextElement.font is TMPro.TMP_FontAsset tmpFont)
            //     // {
            //     //     if (tmpFont != font)
            //     //     {
            //     //         uiTextElement.font = null; // Сбрасываем сначала шрифт на null, чтобы TMP не пытался использовать обычный шрифт
            //     //     }
            //     // }
            // }
        }
    }

}
