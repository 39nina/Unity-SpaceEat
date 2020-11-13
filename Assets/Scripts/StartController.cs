using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    // startボタンを押すとスタート
    public void start()
    {
        SceneManager.LoadScene("GameScene");
    }
}
