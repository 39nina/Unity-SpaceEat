using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    Rigidbody2D foodRig;

    void Start()
    {
        foodRig = GetComponent<Rigidbody2D>();
        float xPos = Random.Range(-700.0f, 700.0f);
        Vector2 startForce = new Vector2(xPos, 0);
        foodRig.AddForce(startForce);
    }

    void Update()
    {
        // 動きが一定以下になったら強制的に止める
        if (foodRig.velocity.magnitude < 0.005)
        {
        foodRig.velocity = Vector2.zero;
        foodRig.isKinematic = true;
        }
    }
}
