using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("TitleScene");//some_senseiシーンをロードする
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}