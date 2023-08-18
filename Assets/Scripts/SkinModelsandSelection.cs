using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinModelsandSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] RacconModels;

    private GameObject currentModel;
    // Текущий объект модели

    private void Awake()
    {
        if (!gameObject.name.Contains("(Clone)")){
            ChooseRacconModel(SaveSkin.instance.currentRaccon);
        }
    }

    private void ChooseRacconModel(int index)
    {
        if (currentModel != null)
        {
            Destroy(currentModel); 
            // Уничтожаем предыдущий объект модели
        }

        currentModel = Instantiate(
            RacconModels[index],
            transform.position,
            transform.rotation,
            transform
        );
    }
}
