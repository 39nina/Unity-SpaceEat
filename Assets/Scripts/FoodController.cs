using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    Rigidbody2D foodRig;
    GameObject NewFood;
    public GameObject opponent;
    GameObject directer;

    // 一定速度以下の状態で、他の同Foodと接触すると消える
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (foodRig)
        {
            if (collision.gameObject.tag == this.gameObject.tag && (foodRig.velocity.magnitude < 0.1))
            {
                opponent = collision.gameObject;
                Destroy(opponent);
                Destroy(this.gameObject);
                directer.GetComponent<GameDirector>().GetPoint();
            }
        }
    }

    void Start()
    {
        directer = GameObject.Find("GameDirector");

        foodRig = this.GetComponent<Rigidbody2D>();
        float xPos = Random.Range(-700.0f, 700.0f);
        Vector2 startForce = new Vector2(xPos, 0);
        foodRig.AddForce(startForce);
    }

    void Update()
    {
        // シーン外に落ちたものは削除
        if (this.gameObject.transform.position.y <= -10)
        {
            Destroy(this.gameObject);
        }

        // 動きが一定以下になったら強制的に止める＆一定落ち着いたらDynamicに戻す
        if (this.gameObject.tag == "NewFood")
        {
            foodRig.bodyType = RigidbodyType2D.Kinematic;
        }
        else if (foodRig.velocity.magnitude >= 0.015)    // 空中ではDynamic
        {
            foodRig.bodyType = RigidbodyType2D.Dynamic;
        }
        else if (foodRig.velocity.magnitude < 0.015 && foodRig.velocity.magnitude >= 0.01)    // 速度が遅くなってきたら静止判定のためにKinematic
        {
            foodRig.velocity = Vector2.zero;
            foodRig.bodyType = RigidbodyType2D.Kinematic;

        }
        else if (foodRig.velocity.magnitude < 0.01)    // 一時停止したらDynamicに戻す
        {
            foodRig.bodyType = RigidbodyType2D.Dynamic;
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

                // IsKinematicをDynamicにする落ちるようにする
                Rigidbody2D NewFoodRig = NewFood.GetComponent<Rigidbody2D>();
                NewFoodRig.bodyType = RigidbodyType2D.Dynamic;
                // 下方向に力を少し加えてIsKinematicにならないようにする
                NewFoodRig.AddForce(new Vector2(0, -300.0f));
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
            // クリックを離すときに、tagをセット
            string tagName = NewFood.GetComponent<SpriteRenderer>().sprite.name;
            NewFood.tag = tagName;
        }
    }
}
