using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    string color;
    void Start(){
        color = gameObject.tag.Split('-')[1];
        // gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        // Material.SetColor(color,Color.red);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверяем, если объект, с которым столкнулся ключ, имеет тег "Player"
        {
           
            
            // Удаляем ключ со сцены
            Destroy(gameObject);
            GameObject[] locks = GameObject.FindGameObjectsWithTag( "lock-" + color);

            foreach (GameObject lockObject in locks)
            {
                lockObject.GetComponent<Animator>().SetTrigger("Open"); // Активируем анимацию на замке
                lockObject.GetComponent<AudioSource>().Play();
                Destroy(lockObject, 1);
            }

        //    Destroy(GameObject.FindWithTag("lock"), 1);
        }
    }
}
