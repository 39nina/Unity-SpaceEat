using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsController : MonoBehaviour
{
    void Start()
    {
        Rigidbody2D fruit = GetComponent<Rigidbody2D>();
        float x = Random.Range(-3.0f, 3.0f);
        Vector2 startForce = new Vector2(x, 4.0f);
        fruit.AddForce(startForce);
    }

    void Update()
    {
        
    }
}
