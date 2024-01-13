using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public float parallaxMargin = 0.3f;
    public GameObject player;
    public Rigidbody2D rb;
    Rigidbody2D rbThis;
    bool moving=false;
    // Start is called before the first frame update
    void Start()
    {
        rbThis = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving) {
            rbThis.velocity = -rb.velocity * parallaxMargin;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
      
        if (col.tag == "Player")
        {
            moving = true;
            rbThis.velocity = -rb.velocity*parallaxMargin ;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.tag == "Player")
        {
            moving = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }

 }
