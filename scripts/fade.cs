using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade : MonoBehaviour
{
    public Color c;
    public float fadeSpeed=0;

    // Update is called once per frame
    void Update()
    {
        c.a -= fadeSpeed;//Color fades
    }


}
