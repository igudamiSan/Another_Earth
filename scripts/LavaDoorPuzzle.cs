using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDoorPuzzle : MonoBehaviour
{
    public static bool LavaBossDead=false;
    public GameObject open;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LavaBossDead) {
            open.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
