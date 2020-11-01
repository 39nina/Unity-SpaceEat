using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    // 大本のPrefab
    public GameObject ApplePrefab, CherryPrefab, StrawberryPrefab, WaterMelonPrefab;
    // cloneされたPdefab
    public GameObject ApplePrefabClone, CherryPrefabClone, StrawberryPrefabClone, WaterMelonPrefabClone;
    Rigidbody2D AppleRig, CherryRig, StrawberryRig, WaterMelonRig;
    Vector2 startPos = new Vector2(0, 3.7f);
    GameObject FoodPrefabs;
    bool isOnce = false;

    // スタート時にフルーツを生成
    void StartOccurFood(GameObject foodPrefab)
    {
        GameObject startPrefab = Instantiate(foodPrefab) as GameObject;
        startPrefab.transform.position = new Vector2(0, 4);
    }

    // ランダムにFoodを１つ生成
    void makeFood(GameObject clone)
    {
        GameObject newPrefab = Instantiate(clone);
        Rigidbody2D newPrefabRig = newPrefab.GetComponent<Rigidbody2D>();
        newPrefabRig.bodyType = RigidbodyType2D.Kinematic;
    }

    void Start()
    {
        StartOccurFood(ApplePrefab);
        StartOccurFood(ApplePrefab);
        StartOccurFood(CherryPrefab);
        StartOccurFood(CherryPrefab);
        StartOccurFood(StrawberryPrefab);
        StartOccurFood(StrawberryPrefab);
        StartOccurFood(WaterMelonPrefab);
        StartOccurFood(WaterMelonPrefab);

        ApplePrefabClone = GameObject.FindGameObjectWithTag("Apple");
        CherryPrefabClone = GameObject.FindGameObjectWithTag("Cherry");
        StrawberryPrefabClone = GameObject.FindGameObjectWithTag("Strawberry");
        WaterMelonPrefabClone = GameObject.FindGameObjectWithTag("WaterMelon");

        AppleRig = ApplePrefabClone.GetComponent<Rigidbody2D>();
        CherryRig = CherryPrefabClone.GetComponent<Rigidbody2D>();
        StrawberryRig = StrawberryPrefabClone.GetComponent<Rigidbody2D>();
        WaterMelonRig = WaterMelonPrefabClone.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ゲーム内の全てのPrefabの動きが止まったら、次のPrefabをランダムで生成
        if (AppleRig.IsSleeping() && CherryRig.IsSleeping() && StrawberryRig.IsSleeping() && WaterMelonRig.IsSleeping() && isOnce == false)
        {
            Debug.Log("停止");
            isOnce = true;
            makeFood(ApplePrefab);
        }
    }
}
