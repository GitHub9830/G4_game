using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed;//プレイヤーの横移動の速度
    Rigidbody2D rb;//プレイヤーのRIgidbody2Dを入れるところ
    float movePower;//プレイヤーの横移動の速度
    bool stopMove;//プレイヤーの横移動が終わったかどうか

    //初期値の設定など
    void Start()
    {
        moveSpeed = 5f;
        rb = this.GetComponent<Rigidbody2D>();
        stopMove = false;
    }

    //毎秒呼び出される
    void Update()
    {
        var hori = Input.GetAxisRaw("Horizontal");//左右方向の入力(横移動)
        var vart = Input.GetAxisRaw("Vertical");//垂直方向の入力(ジャンプ)

        //横移動
        if(hori != 0)
        {
            //押したら動く
            if(rb.velocity.magnitude < moveSpeed)
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
                if (rb.velocity.magnitude > moveSpeed / 4)
                {
                    rb.AddForce(new Vector2(-movePower, 0));
                }
            }
        }


    }
}
