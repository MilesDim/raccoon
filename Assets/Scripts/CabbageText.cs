using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEditor.UI;
using TMPro;

public class CabbageText : MonoBehaviour
{
    public TextMeshProUGUI cabbageText;
    public static int cabbage;
    public raccoon player;
    private GameObject[] effects;
    private int summaryCabbageCount = 0;
    private int pickedCabbageCount = 0;

    public void Start(){
        GameObject[] cabbages = GameObject.FindGameObjectsWithTag("cabbage");
        summaryCabbageCount = cabbages.Length;

        
        effects = GameObject.FindGameObjectsWithTag("win-effect");
    }

    public void OnCabbageCollected() {
        summaryCabbageCount--;
        pickedCabbageCount++;
      

        player.setWin(summaryCabbageCount == 0);

        if(summaryCabbageCount == 0){
            // send message to effect
            foreach(var effect in effects){
                effect.GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
