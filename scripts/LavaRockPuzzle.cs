using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRockPuzzle : MonoBehaviour
{
    public GameObject rock1,rock2,col1,col2;
    // Start is called before the first frame update
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        if (gameObject.name == "collide1" && collision.name == "Rock1")
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;//make rock photo visible
            rock1.SetActive(false);//Deactivate Movable rock
            col1.SetActive(false);//Deactivate blocking collider
        }
        if (gameObject.name == "collide2" && collision.name == "Rock2")
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder= 1;//make rock photo visible
            rock2.SetActive(false);//Deactivate Movable rock
            col2.SetActive(false);//Deactivate blocking collider
        }
    }
}
