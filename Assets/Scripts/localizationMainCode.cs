using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class localizationMainCode : MonoBehaviour
{
    public int language;
    void Start()
    {
        language = PlayerPrefs.GetInt("language", language);
    }

    public void Englishlanguage()
    {
        language = 0;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene("menu");
    }
    public void Hindilanguage()
    {
        language = 1;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene("menu");
    }
    public void Italianlanguage()
    {
        language = 2;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene("menu");
    }
    public void Japaneselanguage()
    {
        language = 3;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene("menu");
    }
    public void Koreanlanguage()
    {
        language = 4;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene("menu");
    }
    public void Polishlanguage()
    {
        language = 5;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene("menu");
    }
    public void Portugueselanguage()
    {
        language = 6;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene("menu");
    }
    public void Russianlanguage()
    {
        language = 7;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene("menu");
    }
    public void Turkishlanguage()
    {
        language = 8;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene("menu");
    }
    public void Ukrainianlanguage()
    {
        language = 9;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene("menu");
    }
    
}
