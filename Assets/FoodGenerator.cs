using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    public GameObject[] FoodPrefabs;    // オブジェクトを格納する配列変数
    Rigidbody2D AppleRig, CherryRig, StrawberryRig, WaterMelonRig;
    int number;   // ランダム情報を入れるための変数
    float delta = 0;    // Prefab生成時のカウント用
    bool isStop;

    // スタート時にフルーツを生成
    void StartOccurFood(GameObject foodPrefab)
    {
        GameObject startPrefab = Instantiate(foodPrefab) as GameObject;
        startPrefab.transform.position = new Vector2(0, 4);
    }

    // ランダムにFoodを１つ生成
    void MakeFood()
    {
        number = Random.Range(0, FoodPrefabs.Length);
        GameObject newPrefab = Instantiate(FoodPrefabs[number]);
        newPrefab.tag = "NewFood";
        Rigidbody2D newPrefabRig = newPrefab.GetComponent<Rigidbody2D>();
        newPrefabRig.bodyType = RigidbodyType2D.Kinematic;
    }
    
    void Start()
    {
        isStop = false;

        // スタート時に８つ自動生成
        for(int i = 0;i < FoodPrefabs.Length; i++)
        {
            StartOccurFood(FoodPrefabs[i]);
            StartOccurFood(FoodPrefabs[i]);
            //StartOccurFood(FoodPrefabs[i]);
        }
    }

    void Update()
    {
        // ゲーム内の全てのPrefabの動きが止まったら、次のPrefabをランダムで生成
        GameObject NewFood = GameObject.FindGameObjectWithTag("NewFood");
        if (!(NewFood))
        {
            delta += Time.deltaTime;

            if (GameObject.FindGameObjectWithTag("Apple"))
            {
                AppleRig = GameObject.FindGameObjectWithTag("Apple").GetComponent<Rigidbody2D>();
                if (AppleRig.IsSleeping())
                {
                    isStop = true;
                }
            }
            if (GameObject.FindGameObjectWithTag("Cherry"))
            {
                CherryRig = GameObject.FindGameObjectWithTag("Cherry").GetComponent<Rigidbody2D>();
                if (CherryRig.IsSleeping())
                {
                    isStop = true;
                }
            }
            if (GameObject.FindGameObjectWithTag("Strawberry"))
            {
                StrawberryRig = GameObject.FindGameObjectWithTag("Strawberry").GetComponent<Rigidbody2D>();
                if (StrawberryRig.IsSleeping())
                {
                    isStop = true;
                }
            }
            if (GameObject.FindGameObjectWithTag("WaterMelon"))
            {
                WaterMelonRig = GameObject.FindGameObjectWithTag("WaterMelon").GetComponent<Rigidbody2D>();
                if (WaterMelonRig.IsSleeping())
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
