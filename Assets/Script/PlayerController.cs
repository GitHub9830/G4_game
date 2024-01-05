using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed;//プレイヤーの横移動の速度
    float movePower;//プレイヤーの横移動の速度
    bool stopMove;//プレイヤーの横移動が終わったかどうか

    Rigidbody2D rb;//プレイヤーのRIgidbody2Dを入れるところ
    SpriteRenderer sr;

    bool canJamp;//ジャンプが出来る時にtrue
    float jampPower;//ジャンプする力

    //初期値の設定など
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
        moveSpeed = 5f;
        stopMove = false;
        canJamp = true;
        jampPower = 100f;
    }

    //毎秒呼び出される
    void Update()
    {
        playerMove();//プレイヤーの左右移動
    }

    //プレイヤーの左右移動
    void playerMove()
    {
        var hori = Input.GetAxisRaw("Horizontal");//左右方向の入力(横移動)
        //var vart = Input.GetAxisRaw("Vertical");//垂直方向の入力(ジャンプ)

        //横移動
        if (hori != 0)
        {
            changeSpriteDir(hori);//進んでいる方向に画像を合わせる
            //押したら動く
            if (Mathf.Abs(rb.velocity.x) < moveSpeed)
            {
                movePower = hori * moveSpeed;
                rb.AddForce(Vector2.right * movePower);
                stopMove = true;
            }
        }
        else
        {
            //ドリフト減少防止用
            if (stopMove)
            {
                //0にするとうまくいきません。おそらく0の時にプログラムの処理が間に合っていないから
                if (Mathf.Abs(rb.velocity.x) > moveSpeed/10)
                {
                    rb.AddForce(Vector2.right * -movePower);
                }
            }
        }
        jamp();//ジャンプの処理
    }


    //進んでいる方向に画像を合わせる
    void changeSpriteDir(float hori)
    {
        if(hori == 1)
        {
            //trueの時画像を反転させる
            sr.flipX = true;
        }
        else
        {
            //falseの時にもとに戻す
            sr.flipX=false;
        }
    }

    //プレイヤーのジャンプの処理
    void jamp()
    {
        if (canJamp)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * jampPower);
                Debug.Log("a");
            }
        }
    }

    //当たり判定（入った瞬間）
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
