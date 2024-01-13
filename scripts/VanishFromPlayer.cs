using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VanishFromPlayer : MonoBehaviour
{
    public GameObject player;
    public float range = 5;
    float distance=100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") { //future player image goes underground
            gameObject.SetActive(false);
        }
    }
}
