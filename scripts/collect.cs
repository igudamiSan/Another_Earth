using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collect : MonoBehaviour
{
    public GameObject player;
    public Text text;
    public GameObject image;
    float distance;
    public float collectRange=1;
    public AudioSource CollectItem;
    public AudioClip collectCling;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= collectRange && Input.GetKeyDown(KeyCode.Z)) {//Collectable in range and Z input
            //add to inventory
            Time.timeScale = 0;
            while (true) {
                image.SetActive(true);
                text.text = "press z to collect " + gameObject.name;
                if (Input.GetKeyDown(KeyCode.Z))//Collect on Z input
                {

                    text.text = "collected " + gameObject.name + " (X)";
                    
                    if (gameObject.name == "Daddyium")
                    {
                        SpaceShipDeposit.daddyiumGot = true;
                        SpaceShipDeposit.onGetKo = true;
                    }
                    else if (gameObject.name == "Gundamium")
                    {
                        SpaceShipDeposit.onGetGun = true;
                    }
                    else if (gameObject.name == "Aloshium") {
                        SpaceShipDeposit.onGetAl = true;
                    }
                    //Time.timeScale = 1;
                    Inventory.InsertToInventory(gameObject.name);
                    gameObject.SetActive(false);
                    break;
                }
                else if (Input.GetKeyDown(KeyCode.X)){//Dont Collect on X input
                        image.SetActive(false);
                        Time.timeScale = 1;
                    
                }
            }
        }
    }
}
