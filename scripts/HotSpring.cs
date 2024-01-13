using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotSpring : MonoBehaviour
{
    bool attackState = false,playerInrange=false;
    public float StateInterval = 1;
    public Sprite h1, h2, h3;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(ChangeState());
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInrange && attackState) { 
            attackState= false;
            playerHealth.RecieveDamage(10);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            playerInrange= true;
            print("inRange");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            playerInrange = false;
        }
    }

    IEnumerator ChangeState() {
        while (true) { 
            yield return new WaitForSeconds(StateInterval);
            sr.sprite = h1;
            yield return new WaitForSeconds(StateInterval);
            sr.sprite = h2;
            yield return new WaitForSeconds(StateInterval);
            sr.sprite = h3;
            attackState= true;
        }
    }
}
