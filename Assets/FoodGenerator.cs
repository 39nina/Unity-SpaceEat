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
    GameObject director;    // GameDirecter
    int foodCount;     // ゲーム内のFoodの数を数えるための変数

    // スタート時にフルーツを生成
    void StartOccurFood(GameObject foodPrefab)
    {
        GameObject startPrefab = Instantiate(foodPrefab) as GameObject;
        startPrefab.transform.position = new Vector2(0, 3.5f);
    }
    
    void Start()
    {
        isStop = false;
        director = GameObject.Find("GameDirector");

        //// スタート時に20こ自動生成
        director.GetComponent<GameDirector>().AddFoods();
        director.GetComponent<GameDirector>().AddFoods();
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
                director.GetComponent<GameDirector>().AddFood();
            }
        }

        // ゲーム内のFoodの数が8を切ったら10個増やす
        foodCount = GameObject.FindGameObjectsWithTag("Avocado").Length + GameObject.FindGameObjectsWithTag("Cherry").Length + GameObject.FindGameObjectsWithTag("Strawberry").Length + GameObject.FindGameObjectsWithTag("WaterMelon").Length + GameObject.FindGameObjectsWithTag("Shrimp").Length + GameObject.FindGameObjectsWithTag("Eggs").Length + GameObject.FindGameObjectsWithTag("Cheese").Length + GameObject.FindGameObjectsWithTag("Pretzel").Length;
        if(foodCount < 9)
        {
            director.GetComponent<GameDirector>().AddFoods();
        }
    }
}
