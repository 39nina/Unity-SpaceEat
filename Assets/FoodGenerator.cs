using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    public GameObject ApplePrefab, CherryPrefab, StrawberryPrefab, WaterMelonPrefab;

    // スタート時にフルーツを生成
    void StartOccurFood(GameObject foodPrefab)
    {
        GameObject startPrefab = Instantiate(foodPrefab) as GameObject;
        startPrefab.transform.position = new Vector2(0, 4);
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
    }

    void Update()
    {

    }
}
