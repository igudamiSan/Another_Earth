using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public static float attacked = 0;
    public Slider slider;
    public GameObject SliderObj;
    public static float range;
    public float MaxHealth = 10;
    public GameObject player;
    float health;
    bool check=false;
    bool resetHealth = false;

    // Start is called before the first frame update
    void Start()
    {
        //initialize health values
        ResetHeath();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerHealth.playerDead)//reset health on player death
        {
            resetHealth = true;
        }
        if (resetHealth)
        {
            ResetHeath();
        }
        slider.value = health;
        if (!check && attacked > 0)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance <= range)
            {
                health -= attacked;
                check = true;
            }
            if (health<=0) {
                if (gameObject.name == "LavaDemon")
                {
                    LavaDemonMove.dead = true;
                    LavaDoorPuzzle.LavaBossDead = true;
                }
                else if (gameObject.name == "FrostGuardian")
                {
                    FrostDemonMove.dead = true;
                }
                else if (gameObject.name == "FrostGuardian (1)")
                {
                    FrostDemonMove1.dead = true;
                }
                else if (gameObject.name == "Boss") { 
                    BossMove.dead = true;
                }
                SliderObj.SetActive(false);
            }//Structure is wrong here as it should have been implemented with individual Script of different enemy type
        }
        else if (attacked == 0) {
            check = false;
        }
    }

    void ResetHeath() {
        health = MaxHealth;
        slider.maxValue = MaxHealth;
        slider.value = MaxHealth;
        resetHealth = false;
    }
    
}
