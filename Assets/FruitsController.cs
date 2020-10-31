using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsController : MonoBehaviour
{
    Rigidbody2D fruit;

    void Start()
    {
        fruit = GetComponent<Rigidbody2D>();
        float xPos = Random.Range(-120.0f, 120.0f);
        Vector2 startForce = new Vector2(xPos, 0);
        fruit.AddForce(startForce);
    }

    void Update()
    {
        if(fruit.velocity.magnitude < 0.002)
        {
            fruit.velocity = Vector2.zero;
            fruit.isKinematic = true;
        }
    }
}
