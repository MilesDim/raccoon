using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public int Level;
     [SerializeField] private GameObject _endingSceneTransition;
   public void ChanagerLoadScene(int scene)
   {
     SceneManager.LoadScene(scene);
     
   }
}
