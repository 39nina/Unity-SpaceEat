using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject scoreText;
    int score = 0;

    public void GetPoint()
    {
        score += 100;
    }

    void Start()
    {
        scoreText = GameObject.Find("Score");
    }

    void Update()
    {
        Debug.Log(score);
        scoreText.GetComponent<Text>().text = "Score：" + score.ToString();
    }
}
