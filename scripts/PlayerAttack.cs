using System.Collections;
using System.Collections.Generic;
//using UnityEditor.U2D.IK;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackDamage = 1;
    public GameObject Player;
    //float distance = 100;
    public static bool attacking = false, attacking1 = false;
    public Collider2D attackCol;
    bool inRange=false;
    public Animator Ani;
    public GameObject area1, area2;
    bool dead=false;
    Rigidbody2D rb;
    //bool attackPlaying = false;

    // Start is called before the first frame update

    private void OnEnable()
    {
        attacking= false;
        attacking1 = false;
    }
    void Start()
    {
        //StartCoroutine(Attack());
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (gameObject.name == "LavaDemon" && LavaDemonMove.dead|| gameObject.name == "FrostGuardian" && FrostDemonMove.dead || gameObject.name == "FrostGuardian (1)" && FrostDemonMove1.dead || gameObject.name == "Boss" && BossMove.dead) { 
            dead= true;
        }
        //distance = Vector2.Distance(transform.position, Player.transform.position);
        if (inRange&&!attacking&&!dead && gameObject.name == "FrostGuardian")
        {

            attacking = true;
            StartCoroutine(Attack());
            
        }
        if (inRange && !attacking1 && !dead && gameObject.name != "FrostGuardian1") {//Mistake of making two scripts for same enemy
            attacking1 = true;
            StartCoroutine(Attack(1));
        }
    }

    void OnTriggerEnter2D(Collider2D gameObj)
    {
        if (gameObj.name == "Player")//Player in attack Range
        {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D gameObj)//Player Out of attack range
    {
        if (gameObj.name == "Player")
        {
            
            inRange = false;

        }
    }

    IEnumerator Attack()
    {
        
        print("attack1");
        if (attackCol.offset.x > 0)
        {
            Ani.SetBool("attackRight", true);
            area1.SetActive(true);

        }
        else if (attackCol.offset.x < 0)
        {
            Ani.SetBool("attackLeft", true);
            area2.SetActive(true);

        }
        yield return new WaitForSeconds(1f);

        if (inRange)
        {
            if (!dead)
            {
                playerHealth.RecieveDamage(attackDamage);
            }
        }

        yield return new WaitForSeconds(1f);

        area1.SetActive(false);
        area2.SetActive(false);
        Ani.SetBool("attackRight", false);
        Ani.SetBool("attackLeft", false);
            
        
        attacking = false;

    }
    IEnumerator Attack(int n)
    {
        
        print("attack2");
        if (gameObject.name == "Boss")
        {
            rb.velocity = Vector3.zero;
        }

            if (attackCol.offset.x > 0)
        {
            Ani.SetBool("attackRight", true);
            area1.SetActive(true);

        }
        else if (attackCol.offset.x < 0)
        {
            Ani.SetBool("attackLeft", true);
            area2.SetActive(true);

        }
        /*if (gameObject.name.StartsWith("Frost")) {
            yield return new WaitForSeconds(1.5f);
        }*/
        if (gameObject.name.StartsWith("Bo"))
        {
            yield return new WaitForSeconds(0.5f);
        }
        else if (gameObject.name == "LavaDemon")
        {
            yield return new WaitForSeconds(1f);
        }
        else {
            yield return new WaitForSeconds(1f);
        }

        

        if (inRange)
        {
            if (!dead)
            {
                playerHealth.RecieveDamage(attackDamage);
            }
        }

        if (gameObject.name.StartsWith("Bo"))
        {
            yield return new WaitForSeconds(0.25f);//Time Between boss attack
        }
        else if (gameObject.name == "LavaDemon")
        {
            yield return new WaitForSeconds(0.5f);//Time Between lava demon attack
        }
        else {
            yield return new WaitForSeconds(1f);//Time Between Frost Guardian attack
        }

        area1.SetActive(false);
        area2.SetActive(false);
        Ani.SetBool("attackRight", false);
        Ani.SetBool("attackLeft", false);
        if (gameObject.name == "Boss") {
            rb.velocity = new Vector2( transform.position.x- Player.transform.position.x, transform.position.y - Player.transform.position.y).normalized*Time.deltaTime*400;//Move To player
            yield return new WaitForSeconds(0.5f);
        }
        attacking1 = false;


    }
}
