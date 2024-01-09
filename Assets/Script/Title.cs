using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//マウス左クリック
        {
            SceneManager.LoadScene("GameScene");//some_senseiシーンをロードする
        }

    }
}