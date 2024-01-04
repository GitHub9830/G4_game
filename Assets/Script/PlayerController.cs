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

    //初期値の設定など
    void Start()
    {
        moveSpeed = 5f;
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
        stopMove = false;
    }

    //毎秒呼び出される
    void Update()
    {
        playerMove();
    }

    //プレイヤーの左右移動
    void playerMove()
    {
        var hori = Input.GetAxisRaw("Horizontal");//左右方向の入力(横移動)
        var vart = Input.GetAxisRaw("Vertical");//垂直方向の入力(ジャンプ)

        //横移動
        if (hori != 0)
        {
            changeSpriteDir(hori);
            //押したら動く
            if (rb.velocity.magnitude < moveSpeed)
            {
                movePower = hori * moveSpeed;
                rb.AddForce(new Vector2(movePower, 0));
                stopMove = true;
            }
        }
        else
        {
            //ドリフト減少防止用
            if (stopMove)
            {
                //0にするとうまくいきません。おそらく0の時にプログラムの処理が間に合っていないから
                if (rb.velocity.magnitude > 1)
                {
                    rb.AddForce(new Vector2(-movePower, 0));
                }
            }
        }




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
}
