using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    Rigidbody2D foodRig;
    GameObject NewFood;
    public GameObject opponent;

    // 一定速度以下の状態で、他の同Foodと接触すると消える
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (foodRig)
        {
            if (collision.gameObject.tag == this.gameObject.tag && (foodRig.velocity.magnitude < 0.07))
            {
                opponent = collision.gameObject;
                Destroy(opponent);
                Destroy(this.gameObject);
            }
        }
    }

    void Start()
    {
        foodRig = this.GetComponent<Rigidbody2D>();
        float xPos = Random.Range(-700.0f, 700.0f);
        Vector2 startForce = new Vector2(xPos, 0);
        foodRig.AddForce(startForce);
    }

    void Update()
    {
        // 動くスピードを減速
        foodRig.velocity *= 0.98f;

        // 動きが一定以下になったら強制的に止める＆衝突判定
        if (foodRig.velocity.magnitude < 0.05)
        {
            foodRig.velocity = Vector2.zero;
            if (transform.position.y < 3.0)
            {
                foodRig.isKinematic = true;
            }
        }

        // 新規生成されたオブジェクトがある時の処理
        NewFood = GameObject.FindGameObjectWithTag("NewFood");
        if (NewFood == true && Input.GetMouseButtonDown(0))
        {
            // クリックした箇所に移動＆クリック箇所をワールド座標に変換する
            Vector3 cameraPos = Input.mousePosition;
            cameraPos.z = 10.0f;     // カメラz位置が-10.0のため
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(cameraPos);
            if(clickPos.x > -2.25f && clickPos.x < 2.25f)
            {
                NewFood.transform.position = new Vector3(clickPos.x, 3.7f, 0.0f);

                // IsKinematicをDynamicにして落ちるようにする
                Rigidbody2D NewFoodRig = NewFood.GetComponent<Rigidbody2D>();
                NewFoodRig.bodyType = RigidbodyType2D.Dynamic;
            }
            else if (clickPos.x < -2.35f)
            {
                NewFood.transform.position = new Vector3(-2.25f, 3.7f, 0.0f);

                // IsKinematicをDynamicにして落ちるようにする
                Rigidbody2D NewFoodRig = NewFood.GetComponent<Rigidbody2D>();
                NewFoodRig.bodyType = RigidbodyType2D.Dynamic;
            }
            else if (clickPos.x > 2.35f)
            {
                NewFood.transform.position = new Vector3(2.25f, 3.7f, 0.0f);

                // IsKinematicをDynamicにして落ちるようにする
                Rigidbody2D NewFoodRig = NewFood.GetComponent<Rigidbody2D>();
                NewFoodRig.bodyType = RigidbodyType2D.Dynamic;
            }
        }
        else if (NewFood == true && Input.GetMouseButtonUp(0))
        {
            // クリックを離すときに、次の新オブジェクト追加のためセット
            string tagName = NewFood.GetComponent<SpriteRenderer>().sprite.name;
            NewFood.tag = tagName;
        }
    }
}
