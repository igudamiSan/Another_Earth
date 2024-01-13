using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class caveReturn : MonoBehaviour
{
    public GameObject image;
    public Text text;

    void OnTriggerEnter2D(Collider2D col) {
        

        if (col.name == "Player") {
            
            image.SetActive(true);
            text.text = "Go back to surface?(Z/X)";
            //Time.timeScale = 0;
            SwitchCamera.returnSurfaceRequest = true;//Go back to Cave Entrance
            Time.timeScale = 0;
        }
        
    }
}
