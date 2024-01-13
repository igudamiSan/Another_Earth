using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandTileDuplication : MonoBehaviour
{

    public int height = 100;
    public int width = 100;
    public int offX=0, offY=0;
    public GameObject tile;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Instantiate(tile, new Vector3(i + offX, j + offY, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
