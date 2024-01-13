using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostDemonMove : MonoBehaviour
{
    //public CircleCollider2D SeeCollider;
    public GameObject player;
    public static bool playerFound = false;
    public float seeRange = 2;
    public float speed=1;
    public float playerReach = 1;
    Rigidbody2D rb;
    bool outOfRange = true;
    bool reachedPlayer = false;
    public Animator Ani;
    float distance;
    public Collider2D attackCollider;
    public static bool dead=false;
    bool audioPlayed = false;
    
    //Same as LavaDemonMove
    void Start()
    {
        rb=gameObject.GetComponent<Rigidbody2D>();
        
    }

   
    void Update()
    {
        if (dead) {
            Ani.SetBool("dead", true);
        }
       
        if (playerFound)
        {
            distance = 0;
        }
        else
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
        }
        if (distance < playerReach)
        {
            reachedPlayer = true;
        }
        else {
            reachedPlayer = false;
        }
        if (distance < seeRange)
        {
            outOfRange = false;
            if (!audioPlayed)
            {
                PlayAudio.IcePlay = true;
                audioPlayed= true;
            }
        }
        else {
            outOfRange = true;
            rb.velocity = Vector2.zero;
        }
        if (!outOfRange && !reachedPlayer&& !PlayerAttack.attacking&&!dead)
        {
            print("movable");
            rb.velocity = Time.deltaTime * new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized * speed;
            if (rb.velocity.x < 0)
            {
                Ani.SetBool("left", true);
                Ani.SetBool("right", false);
                attackCollider.offset = new Vector2(-0.356f, -0.0814f);
            }
            else if (rb.velocity.x > 0)
            {
                Ani.SetBool("left", false);
                Ani.SetBool("right", true);

                attackCollider.offset = new Vector2(0.356f, 0.0814f);
            }
            else {
                Ani.SetBool("left", false);
                Ani.SetBool("right", false);


            }
            if (rb.velocity.y == 0)
            {
                Ani.SetBool("vertical", false);
            }
            else
            {
                Ani.SetBool("vertical", true); ;
            }
        }
       
        else {
            rb.velocity = Vector2.zero;
            Ani.SetBool("vertical", false);
            Ani.SetBool("right", false);
            Ani.SetBool("left", false);


        }

    }  
}
