using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy1 : MonoBehaviour
{
    public CircleCollider2D SeeCollider;
    public GameObject player;
    public float seeRange = 2;
    public float speed=1;
    Rigidbody2D rb;
    bool outOfRange = true;
    // Start is called before the first frame update
    void Start()
    {
        rb=gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //float dist=Mathf.Sqrt()
        if (!outOfRange)
        {
            rb.velocity = Time.deltaTime * new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized * speed;
        }
    }
    void OnTriggerEnter2D(Collider2D gameObj) {
        if (gameObj.name == "Player") {
            outOfRange = false;
        }
    }

    void OnTriggerExit2D(Collider2D gameObj)
    {
        if (gameObj.name == "Player")
        {
            outOfRange = true;
            rb.velocity = Vector2.zero;
            
        }
    }

    
}
