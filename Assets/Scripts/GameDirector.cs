using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject scoreText;
    int score = 0;
    int number;   // Foodを１つ追加する際のランダム情報を入れるための変数
    GameObject generator;
    GameObject[] foodPrefabs;
    GameObject clearImage;    // クリア時に表示する画面
    GameObject gameOverImage;    // ゲームオーバー時に表示する画面

    public void GetPoint()
    {
        score += 100;
    }

    // スコアによってランダムにFoodを１つ生成
    public void AddFood()
    {
        if(score < 1500)
        {
            number = Random.Range(0, 5);
        }
        else if (score >= 1500 && score < 2400)
        {
            number = Random.Range(0, 6);
        }
        else if (score >= 2400 && score < 3600)
        {
            number = Random.Range(0, 7);
        }
        else if (score >= 3600 && score <= 5000)
        {
            number = Random.Range(0, 8);
        }
        // 5000点でゲーム終了
        if (score < 5000)
        {
            GameObject newPrefab = Instantiate(foodPrefabs[number]);
            newPrefab.tag = "NewFood";
            Rigidbody2D newPrefabRig = newPrefab.GetComponent<Rigidbody2D>();
            newPrefabRig.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    // スコアによってランダムにFoodを10こ生成
    public void AddFoods()
    {
        for (int i = 0; i < 10; i++)
        {
            if (score < 1500)
            {
                number = Random.Range(0, 5);
            }
            else if (score >= 1500 && score < 2400)
            {
                number = Random.Range(0, 6);
            }
            else if (score >= 2400 && score < 3600)
            {
                number = Random.Range(0, 7);
            }
            else if (score >= 3600 && score <= 5000)
            {
                number = Random.Range(0, 8);
            }

            // 5000点でゲーム終了
            if (score < 5000)
            {
                GameObject newPrefab = Instantiate(foodPrefabs[number]);
                float rnd = Random.Range(-2.25f, 2.25f);
                newPrefab.transform.position = new Vector3(rnd, 3.7f, 0);
                // 下方向に力を少し加えてIsKinematicにならないようにする
                newPrefab.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -300.0f));
            }
        }
    }

    // scoreが6,000点を超えたときにclearImageを表示する
    public void clear()
    {
        if (score >= 5000)
        {
            clearImage.SetActive(true);
        }
    }

    // 速度が一定以下で線を超えたときにclearImageを表示する
    public void gameover()
    {
        
    }

    // retryボタンを押すとリトライ
    public void retry()
    {
        SceneManager.LoadScene("GameScene");
    }

    void Start()
    {
        scoreText = GameObject.Find("Score");
        generator = GameObject.Find("FoodGenerator");
        foodPrefabs = generator.GetComponent<FoodGenerator>().FoodPrefabs;
        clearImage = GameObject.Find("ClearButton");
        clearImage.SetActive(false);
        gameOverImage = GameObject.Find("GameOverButton");
        gameOverImage.SetActive(false);
    }

    void Update()
    {
        scoreText.GetComponent<Text>().text = "Score：" + score.ToString();
        clear();
    }
}
