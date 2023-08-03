using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    public Transform Player; // Ссылка на блок, на котором должны активироваться шипы
    public Collider spikesCollider; // Ссылка на Collider шипов
    private bool isPlayerOnBlock = false;
    private bool isPlayerOnBlockPrev = false;
    public Animator spikeAnimator;
    private bool isActive = false;
    [SerializeField] private GameObject _endingSceneTransition;
 
    void Start(){
    }

    private void FixedUpdate()
    {
        // Проверяем, находится ли персонаж на блоке
        isPlayerOnBlock = Player.GetComponent<Collider>().bounds.Contains(transform.position); 
        if(isPlayerOnBlock == false && isPlayerOnBlockPrev == true)
        {
            spikeAnimator.SetTrigger("ActivateSpike"); 
            // Активируем Collider шипов, если персонаж ушел с блока
            // spikesCollider.enabled = true;
            isActive = true;
        }else if (isPlayerOnBlock == true && isActive == true){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // Invoke("FixedUpdate", 0.01f);
            _endingSceneTransition.SetActive(true); 
        }

        isPlayerOnBlockPrev = isPlayerOnBlock;
    }

//  private void OnCollisionEnter(Collision collision)
//     {
//         if (collision.gameObject.tag == "Player")
//         {
//             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//         }
//     }

    
}

