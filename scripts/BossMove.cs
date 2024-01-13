using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
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
    public AudioClip run;

    // Start is called before the first frame update
    void Start()
    {
        rb=gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dead) {
            print("dead");
            Ani.SetBool("dead", true);
        }
        //print(rb.velocity);
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
        }
        else {
            outOfRange = true;
            rb.velocity = Vector2.zero;
        }
        //float dist=Mathf.Sqrt()
        if (!outOfRange && !reachedPlayer&& !PlayerAttack.attacking1&&!dead)
        {
            print("going for player");
            rb.velocity = Time.deltaTime * new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized * speed;
            if (rb.velocity.x < 0)
            {
                Ani.SetBool("left", true);
                Ani.SetBool("right", false);
                attackCollider.offset = new Vector2(-0.56f, -0.35f);
            }
            else if (rb.velocity.x > 0)
            {
                Ani.SetBool("left", false);
                Ani.SetBool("right", true);

                attackCollider.offset = new Vector2(0.56f, -0.35f);
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
        /*else if (PlayerAttack.attacking) {
            rb.velocity = Vector2.zero;
        }*/
        else {
            if (gameObject.name != "Boss")
            {
                rb.velocity = Vector2.zero;
            }
            Ani.SetBool("vertical", false);
            Ani.SetBool("right", false);
            Ani.SetBool("left", false);


        }

    }  
}
