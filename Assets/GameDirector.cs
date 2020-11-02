using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject scoreText;
    int score = 0;
    int number;   // Foodを１つ追加する際のランダム情報を入れるための変数
    GameObject generator;
    GameObject[] foodPrefabs;

    public void GetPoint()
    {
        score += 100;
    }

    // スコアによってランダムにFoodを１つ生成
    public void AddFood()
    {
        if(score < 1000)
        {
            number = Random.Range(0, 4);
        }
        else if (score >= 1000 && score < 2000)
        {
            number = Random.Range(0, 5);
        }
        else if (score >= 2000 && score < 3000)
        {
            number = Random.Range(0, 6);
        }
        else if (score >= 3000)
        {
            number = Random.Range(0, 8);
        }
        GameObject newPrefab = Instantiate(foodPrefabs[number]);
        newPrefab.tag = "NewFood";
        Rigidbody2D newPrefabRig = newPrefab.GetComponent<Rigidbody2D>();
        newPrefabRig.bodyType = RigidbodyType2D.Kinematic;
    }

    void Start()
    {
        scoreText = GameObject.Find("Score");
        generator = GameObject.Find("FoodGenerator");
        foodPrefabs = generator.GetComponent<FoodGenerator>().FoodPrefabs; 
    }

    void Update()
    {
        scoreText.GetComponent<Text>().text = "Score：" + score.ToString();
    }
}
