using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelection : MonoBehaviour
{
    private int currentRaccon;
    public Button chooseButton;

    private void Start()
    {
        currentRaccon = SaveSkin.instance.currentRaccon;
        SelectionRaccon(currentRaccon);

        // Назначаем функцию на событие кнопки выбора
       chooseButton.onClick.AddListener(SelectCurrentRaccon);

    }
    private void SelectionRaccon(int _index)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        } 
    }
    public void ChangeRaccon(int _change)
    { 
        currentRaccon += _change; 

        if (currentRaccon > transform.childCount - 1){
            currentRaccon = 0;
        }else if (currentRaccon < 0){
            currentRaccon = transform.childCount - 1;
        } 
        SelectionRaccon(currentRaccon);
    }
    private void SelectCurrentRaccon()
    {
    SaveSkin.instance.currentRaccon = currentRaccon;
    SaveSkin.instance.Save();
    PlayerPrefs.SetInt("SelectedRaccon", currentRaccon); 
    }
    }
