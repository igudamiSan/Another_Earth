using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    float range = 2;
    public float damage = 2;
    public GameObject pickAxe;
    public static bool attacking = false;
    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth.range = range;
        if (PlayerPrefs.GetInt("Pickaxe", 0) == 2) {
            range = 4;
            damage = 4;
        }
        if (PlayerPrefs.GetInt("Pickaxe", 0) == 1)
        {
            damage = 3;
        }
        if (PlayerPrefs.GetInt("Pickaxe", 0) == 3) {
                damage = 5;
                range = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt) && !attacking&& !playerHealth.playerDead) {
            EnemyHealth.attacked = damage;
            StartCoroutine(SwingAxe());
            attacking = true;
        }
    }
    IEnumerator SwingAxe() {
        int n = 0;
        pickAxe.SetActive(true);
        while (true) {
            pickAxe.transform.Rotate(0,0,Time.deltaTime*-2000,Space.Self);
            yield return null;
            n++;
            if (n == 100) {
                break;
            }
        }
        pickAxe.SetActive(false);

        yield return new WaitForSeconds(0.6f);

        pickAxe.transform.rotation = Quaternion.Euler(0f,0f,-45f);
        EnemyHealth.attacked = 0;
        attacking= false;
    }
}
