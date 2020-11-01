using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    public GameObject[] FoodPrefabs;    // オブジェクトを格納する配列変数
    Rigidbody2D AppleRig, CherryRig, StrawberryRig, WaterMelonRig;
    int number;   // ランダム情報を入れるための変数
    float delta = 0;    // Prefab生成時のカウント用

    // スタート時にフルーツを生成
    void StartOccurFood(GameObject foodPrefab)
    {
        GameObject startPrefab = Instantiate(foodPrefab) as GameObject;
        startPrefab.transform.position = new Vector2(0, 4);
    }

    // ランダムにFoodを１つ生成
    void makeFood()
    {
        number = Random.Range(0, FoodPrefabs.Length);
        GameObject newPrefab = Instantiate(FoodPrefabs[number]);
        newPrefab.tag = "NewFood";
        Rigidbody2D newPrefabRig = newPrefab.GetComponent<Rigidbody2D>();
        newPrefabRig.bodyType = RigidbodyType2D.Kinematic;
    }

    void Start()
    {
        // スタート時に８つ自動生成
        for(int i = 0;i < FoodPrefabs.Length; i++)
        {
            StartOccurFood(FoodPrefabs[i]);
            StartOccurFood(FoodPrefabs[i]);
        }

        // cloneされたオブジェクトのRigidbodyを設定
        AppleRig = GameObject.FindGameObjectWithTag("Apple").GetComponent<Rigidbody2D>();
        CherryRig = GameObject.FindGameObjectWithTag("Cherry").GetComponent<Rigidbody2D>();
        StrawberryRig = GameObject.FindGameObjectWithTag("Strawberry").GetComponent<Rigidbody2D>();
        WaterMelonRig = GameObject.FindGameObjectWithTag("WaterMelon").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ゲーム内の全てのPrefabの動きが止まったら、次のPrefabをランダムで生成
        GameObject NewFood = GameObject.FindGameObjectWithTag("NewFood");
        if (!(NewFood))
        {
            delta += Time.deltaTime;
            if (AppleRig.IsSleeping() && CherryRig.IsSleeping() && StrawberryRig.IsSleeping() && WaterMelonRig.IsSleeping() && delta > 1)
            {
                delta = 0;
                makeFood();
            }
        }
    }
}
