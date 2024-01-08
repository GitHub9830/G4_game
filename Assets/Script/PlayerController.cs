using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //移動関連
    float moveSpeed;//プレイヤーの横移動の速度
    float movePower;//プレイヤーの横移動の速度
    bool stopMove;//プレイヤーの横移動が終わったかどうか

    Rigidbody2D rb;//プレイヤーのRIgidbody2Dを入れるところ
    public GameObject playerSprite;
    SpriteRenderer sr;
    public GameObject background;
    MoveBackGround moveBackGround;//背景

    //ジャンプ関連
    bool canJamp;//ジャンプできるか
    float jampPos;//ジャンプした地点
    float maxJampPos;//ジャンプできる最高地点
    float jampHeight;//ジャンプする高さ
    float jampUpTime;//ジャンプで上昇する時間
    float jampAcc;//ジャンプの加速度
    bool jampUpPos;//ジャンプで上昇中
    float maxJampAcc;//ジャンプの最大加速度
    float jampFlyTime;//ジャンプ時の浮遊時間
    float maxJampFlyTime;//ジャンプ時の最大浮遊時間

    //マップのサイズ
    float mapSize;

    //初期値の設定など
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sr = playerSprite.GetComponent<SpriteRenderer>();
        moveBackGround = background.GetComponent<MoveBackGround>();
        
        moveSpeed = 5f;
        stopMove = false;

        canJamp = true;
        jampHeight = 5f;
        jampPos = rb.position.y;
        maxJampPos = jampPos + jampHeight;
        jampUpTime = 0.2f;
        jampAcc = jampHeight / jampUpTime;
        jampUpPos = false;
        maxJampAcc = jampAcc * 2;
        jampFlyTime = 0;
        maxJampFlyTime = 0.1f;

        mapSize = 20;
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
        rb.position = new Vector2(Mathf.Clamp(rb.position.x,-mapSize,mapSize),rb.position.y);
        moveBackGround.moveBackGround(rb.position.x);
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

    void goDown()
    {
        if (canJamp) return;
        if(rb.velocity.y != 0)
        {
            if (rb.velocity.y > -maxJampAcc)
            {
                rb.AddForce(Vector2.up * -jampAcc * 2);
            }
        }
    }

    //プレイヤーのジャンプの処理
    void jamp()
    {
        if (canJamp)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jampPos = rb.position.y;
                maxJampPos = jampPos + jampHeight;
                jampAcc = jampHeight / jampUpTime;

                canJamp = false;
                jampUpPos = true;
            }
        }
        else
        {
            if (jampUpPos)
            {
                if (rb.position.y >= maxJampPos)
                {
                    jampFlyTime = 0;
                    jampUpPos = false;
                }
                else
                {
                    if(rb.velocity.y < jampAcc)
                    {
                        rb.AddForce(Vector2.up * jampAcc);
                    }
                }
            }
            else
            {
                if (rb.velocity.y == 0)
                {
                    canJamp = true;
                    return;
                }
                if (jampFlyTime >= maxJampFlyTime)
                {
                    if(rb.position.y > jampPos)
                    {
                        if (rb.velocity.y > -jampAcc)
                        {
                            rb.AddForce(Vector2.up * -jampAcc);
                        }
                    }
                    else
                    {
                        if(rb.velocity.y > -maxJampAcc)
                        {
                            rb.AddForce(Vector2.up * -jampAcc);
                        }
                    }
                }
                else
                {
                    jampFlyTime += Time.deltaTime;
                }
            }
        }
        Debug.Log(canJamp);
    }

    //当たり判定（入った瞬間）
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
