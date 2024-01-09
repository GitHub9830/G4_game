using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj: MonoBehaviour
{
    RemainEnemy remainEnemy;
    void Start()
    { 
        remainEnemy = GameObject.Find("GameManager").GetComponent<RemainEnemy>();
    }

    void Update()
    {

    }

 
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bonfire"))//さっきつけたTagutukeruというタグがあるオブジェクト限定で～という条件の下
        {
            Destroy(gameObject);//このゲームオブジェクトを消滅させる
            remainEnemy.downEnemyNum();
        }
    }
}