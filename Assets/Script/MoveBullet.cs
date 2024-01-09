using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public GameObject player;
    RemainEnemy remainEnemy;
    PlayerController controller;
    float moveSpeed;
    Rigidbody2D rb;
    float time;
    void Start()
    {
        player = GameObject.Find("Player");
        remainEnemy = GameObject.Find("GameManager").GetComponent<RemainEnemy>();
        controller = player.GetComponent<PlayerController>();
        rb = this.GetComponent<Rigidbody2D>();
        moveSpeed = 10f * controller.saveHori;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, 0);
        time += Time.deltaTime;
        if(time > 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            remainEnemy.downEnemyNum();
            controller.killEnemy++;
        }
    }
}
