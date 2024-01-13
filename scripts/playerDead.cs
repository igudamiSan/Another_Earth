using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDead : MonoBehaviour
{
    public GameObject Player;
    public GameObject GameOverScreen;
    public static bool respawned = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (playerHealth.playerDead) {
               GameOverScreen.SetActive(true);
        }
    }

    public void respawn() {
        SpaceShipDeposit.callOnDeath = true;
        respawned= true;
        Player.SetActive(false);
        Player.SetActive(true);
        SwitchCamera.onPlayerdeath = true;
        GameOverScreen.SetActive(false);
        playerHealth.playerDead = false;
    }
}
