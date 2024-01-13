using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMove : MonoBehaviour
{
    static bool rock1 = false, rock2 = false;
    public GameObject open, close;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (rock1 && rock2)
        {
            open.SetActive(true);
            close.SetActive(false);
        }
        else
        {
            
            open.SetActive(false);
            close.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Rock1")
        {
            rock1 = true;
        }
        else if (col.name == "Rock2")
        {
            rock2 = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Rock1")
        {
            rock1 = false;
            print("closed");
        }
        else if (col.name == "Rock2")
        {
            rock2 = false;
        }
    }
}
