using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Experimental.Rendering.Universal;

public class LightUp : MonoBehaviour
{
    public static int lightsOn=0,lightsOff=5;
    Light2D light;
    bool status = false;
    public GameObject door;
    // Start is
    // called before the first frame update
    
    void Start()
    {
        light = gameObject.GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightsOn == 4 && lightsOff == 5)
        {
            door.SetActive(false);
            JawaTalk.doorOpen = true;
        }
        else { 
            door.SetActive(true);  
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print("Light");
        status = !status;
        if (status)
        {
            light.intensity = 1;
            if (gameObject.name.StartsWith("on")) {
                lightsOn++;
            } else if (gameObject.name.StartsWith("Free")) {
                lightsOff--;
            }
        }
        else { 
            light.intensity = 0;
            if (gameObject.name.StartsWith("on"))
            {
                lightsOn--;
            }
            else if (gameObject.name.StartsWith("Free"))
            {
                lightsOff++;
            }
        }
    }
}
