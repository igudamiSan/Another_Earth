using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignorePLayerCollision : MonoBehaviour
{
    public Collider2D player;
    // Start is called before the first frame update
    void OnEnable()
    {
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(),player);
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
    }
}
