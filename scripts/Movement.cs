using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator Ani;
    public float speed = 1;
    public float MaxStamina = 1000;
    float stamina;
    float walkspeed, runSpeed;
    public Slider slider;
    public static bool playerStationary1 = false, cutscene = false;
    public AudioClip walk;
    public AudioSource Moving;
    public float timeGap = 1;
    bool runGap = false, walkGap = false;
    // Start is called before the first frame update

    private void OnEnable()
    {
        cutscene = false;
        playerStationary1 = false;

    }

    void Start()
    {
        stamina = MaxStamina;
        walkspeed = speed;
        runSpeed = 2 * speed;
        slider.maxValue = MaxStamina;
        slider.minValue = 0;
        slider.value = MaxStamina;
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(StaminaCheck());
    }

    // Update is called once per frame
    void Update()
    {
        //Run/Walk setting
        slider.value = stamina;
        if (Input.GetKeyDown(KeyCode.LeftShift) && stamina!=0)
        {
            speed = runSpeed;
            print("runspeed");
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = walkspeed;
            print("walkspeed");
        }
        if (playerHealth.playerDead == false)//While player not dead
        {
            Move();//Move Based on input
            MoveAnimation();//Animate based on input
            if (rb.velocity != Vector2.zero)
            {
                if (!runGap)// not in time b/w footsteps
                {

                    Moving.PlayOneShot(walk);
                    if (speed == walkspeed)
                    {
                        StartCoroutine(AudioPlay(true));//walk sound
                        
                    }
                    else
                    {
                        StartCoroutine(AudioPlay(false));//runsound
                    }
                    runGap = true;


                }
            }
            else
            {
                Moving.Stop();//Stop footstep sound
                rb.velocity = Vector2.zero;

            }
        }
    }

        IEnumerator AudioPlay(bool n)//play footsetp sound
        {

            if (n)
            {


                yield return new WaitForSeconds(timeGap);
                runGap = false;
            }
            else
            {


                yield return new WaitForSeconds(timeGap /1.5f);
                runGap = false;
            }
        }

        IEnumerator StaminaCheck()
        {
            
            while (true)
            {
            if (speed == runSpeed && stamina != 0)
            {
                if (stamina > 0)
                {
                    stamina--;
                }
                else
                {
                    stamina = 0;
                }
                
            }
            if (stamina == 0 ) {
                speed = walkspeed;

            }
            if (stamina < MaxStamina && speed==walkspeed) { 
                        
                 stamina += 0.1f + Mathf.Abs(stamina) * 0.3f;
            }
                
               
                yield return new WaitForSeconds(0.3f);
            }

        }//Set stamina whwn running, replenishing
        void Move()//Move on input
        {

            if (!playerStationary1 && !cutscene)
            {
                rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal") * Time.deltaTime, rb.velocity.y);

                rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * speed * Time.deltaTime);
            }
            else if (!cutscene && playerStationary1)
            {
                //print("no move" + playerStationary1);
                rb.velocity = Vector2.zero;
            }
        }

        void MoveAnimation()//Animation on movement input
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {

                Ani.SetBool("left", true);
                Ani.SetBool("right", false);

            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                Ani.SetBool("left", false);
                Ani.SetBool("right", true);
            }
            else
            {
                Ani.SetBool("left", false);
                Ani.SetBool("right", false);
            }

            if (Input.GetAxisRaw("Vertical") != 0)
            {
                Ani.SetBool("vertical", true);
            }
            else
            {
                Ani.SetBool("vertical", false);
            }

        
    
        }    
}
