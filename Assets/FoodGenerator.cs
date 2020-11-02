using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    public GameObject[] FoodPrefabs;    // オブジェクトを格納する配列変数
    Rigidbody2D AvocadoRig, CherryRig, StrawberryRig, WaterMelonRig;
    int number;   // ランダム情報を入れるための変数
    float delta = 0;    // Prefab生成時のカウント用
    bool isStop;
    int score;

    // スタート時にフルーツを生成
    void StartOccurFood(GameObject foodPrefab)
    {
        GameObject startPrefab = Instantiate(foodPrefab) as GameObject;
        startPrefab.transform.position = new Vector2(0, 3.5f);
    }

    // ランダムにFoodを１つ生成
    void MakeFood()
    {
        if(score < 2000)
        {
            number = Random.Range(0, 3);
        }
        else if (score >= 2000 && score < 3000)
        {
            number = Random.Range(0, 4);
        }
        else if (score >= 3000 && score < 4000)
        {
            number = Random.Range(0, 5);
        }
        else if (score >= 4000)
        {
            number = Random.Range(0, 7);
        }
        GameObject newPrefab = Instantiate(FoodPrefabs[number]);
        newPrefab.tag = "NewFood";
        Rigidbody2D newPrefabRig = newPrefab.GetComponent<Rigidbody2D>();
        newPrefabRig.bodyType = RigidbodyType2D.Kinematic;
    }
    
    void Start()
    {
        isStop = false;

        // スタート時に８つ自動生成
        for(int i = 0;i < 4; i++)
        {
            StartOccurFood(FoodPrefabs[i]);
            StartOccurFood(FoodPrefabs[i]);
            StartOccurFood(FoodPrefabs[i]);
        }
    }

    void Update()
    {
        // ゲーム内の全てのPrefabの動きが止まったら、次のPrefabをランダムで生成
            GameObject NewFood = GameObject.FindGameObjectWithTag("NewFood");
        if (!(NewFood))
        {
            delta += Time.deltaTime;

            if (GameObject.FindGameObjectWithTag("Avocado"))
            {
                AvocadoRig = GameObject.FindGameObjectWithTag("Avocado").GetComponent<Rigidbody2D>();
                if (AvocadoRig.velocity.magnitude < 0.01)
                {
                    isStop = true;
                }
            }
            if (GameObject.FindGameObjectWithTag("Cherry"))
            {
                CherryRig = GameObject.FindGameObjectWithTag("Cherry").GetComponent<Rigidbody2D>();
                if (CherryRig.velocity.magnitude < 0.01)
                {
                    isStop = true;
                }
            }
            if (GameObject.FindGameObjectWithTag("Strawberry"))
            {
                StrawberryRig = GameObject.FindGameObjectWithTag("Strawberry").GetComponent<Rigidbody2D>();
                if (StrawberryRig.velocity.magnitude < 0.01)
                {
                    isStop = true;
                }
            }
            if (GameObject.FindGameObjectWithTag("WaterMelon"))
            {
                WaterMelonRig = GameObject.FindGameObjectWithTag("WaterMelon").GetComponent<Rigidbody2D>();
                if (WaterMelonRig.velocity.magnitude < 0.01)
                {
                    isStop = true;
                }
            }
            if(isStop == true && delta > 1)
            {
                delta = 0;
                MakeFood();
            }
        }
    }
}
