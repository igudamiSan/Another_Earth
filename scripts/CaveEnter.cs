using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveEnter : MonoBehaviour
{
    BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<BoxCollider2D>();
    }


    void OnCollisionEnter2D(Collision2D player) {//camera switch on Entering Cave
        if (player.gameObject.tag == "Player" && gameObject.name == "CaveDown")
        {
            SwitchCamera.Entered = 1;
            SwitchCamera.caveNum = 1;
        }
        else if (player.gameObject.tag == "Player" && gameObject.name == "CaveUp") { 
            
            SwitchCamera.Entered = 2;
            SwitchCamera.caveNum = 2;
        }
        else if (player.gameObject.tag == "Player" && gameObject.name == "CaveLeft")
        {

            SwitchCamera.Entered = 3;
            SwitchCamera.caveNum = 3;
        }

    }
}
