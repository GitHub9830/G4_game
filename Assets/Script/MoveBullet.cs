using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    GameObject gameManager;
    GameObject player;
    RemainEnemy remainEnemy;
    WaveManager waveManager;
    PlayerController controller;
    ShotBullet shotBullet;
    float moveSpeed;
    Rigidbody2D rb;
    float time;
    void Start()
    {
        player = GameObject.Find("Player").gameObject;
        gameManager = GameObject.Find("GameManager").gameObject;
        controller = player.GetComponent<PlayerController>();
        shotBullet = player.GetComponent<ShotBullet>();
        shotBullet.addBulletNum();
        remainEnemy = gameManager.GetComponent<RemainEnemy>();
        waveManager = gameManager.GetComponent<WaveManager>();
        rb = this.GetComponent<Rigidbody2D>();
        moveSpeed = 10f * controller.saveHori;
        if(moveSpeed == 0)
        {
            moveSpeed = -10f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, 0);
        time += Time.deltaTime;
        if(time > 5)
        {
            Destroy(gameObject);
            shotBullet.disBulletNum();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            shotBullet.disBulletNum();
            remainEnemy.downEnemyNum();
            waveManager.addKillCount();
        }
    }
}
