using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundbackground : MonoBehaviour
{
    [Header("Tags")]
    [SerializeField] private string createdTang;

    private void Awake()
    {
        GameObject gameObject = GameObject.FindWithTag(this.createdTang);
        if (gameObject != null)
        {
           Destroy(this.gameObject);
        }
        else 
        {
            this.gameObject.tag = this.createdTang;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
