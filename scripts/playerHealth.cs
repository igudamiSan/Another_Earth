using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public static bool playerDead = false;
    public Animator Ani;
    public float maxHP = 10;
    public Slider slider;
    float currHP;
    public static float damage = 0;
    public static bool resetHp = false;
    public AudioClip d1,d2,d3,d4,d5;
    public AudioSource deathaplayer;
    bool deadSounPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        currHP = maxHP;
        slider.maxValue = maxHP;
        slider.value = maxHP;
        slider.minValue = 0;
        deadSounPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(resetHp){
            deadSounPlayed = false;
            print("health restored");
            currHP = maxHP;
            slider.value = maxHP;
            Ani.SetBool("dead", false);
            resetHp = false;
        }
        if (damage != 0) {
            currHP -= damage;
            slider.value = currHP;
            damage = 0;
        }
        if (currHP <= 0) {
           // Debug.Log("player dead");
            playerDead = true;
            Ani.SetBool("dead",true);
            if (!deadSounPlayed) {
                deathaplayer.PlayOneShot(randomize());
                deadSounPlayed=true;
            }
        }
    }

    AudioClip randomize() {
        AudioClip a;
        int n=Random.Range(0,5);
        if (n == 0) {
            a = d1;
        }else if (n == 1)
        {
            a = d2;

        }
        else if (n == 2)
        {
            a = d3;

        }
        else if (n == 3)
        {
            a = d4;

        }
        else 
        {
            a = d5;

        }
        return a; 
    }
    public static void RecieveDamage(float dmg) {
        damage = dmg;
    }
}
