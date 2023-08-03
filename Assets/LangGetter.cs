using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangGetter : MonoBehaviour
{ 
    public LanguageManager langManager;
    // LanguageManager langManager;
    void Awake(){
        // languageManager = GetComponent<LanguageManager>();
        Debug.Log("Awake LangGetter");
        langManager.ChangeLanguage(true);
    }
    void OnEnable(){
        Debug.Log("Enable LangGetter");
        langManager.ChangeLanguage(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
