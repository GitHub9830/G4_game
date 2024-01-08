using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //�ړ��֘A
    float moveSpeed;//�v���C���[�̉��ړ��̑��x
    float movePower;//�v���C���[�̉��ړ��̑��x
    bool stopMove;//�v���C���[�̉��ړ����I��������ǂ���

    Rigidbody2D rb;//�v���C���[��RIgidbody2D������Ƃ���
    public GameObject playerSprite;
    SpriteRenderer sr;
    public GameObject background;
    MoveBackGround moveBackGround;//�w�i

    //�W�����v�֘A
    bool canJamp;//�W�����v�ł��邩
    float jampPos;//�W�����v�����n�_
    float maxJampPos;//�W�����v�ł���ō��n�_
    float jampHeight;//�W�����v���鍂��
    float jampUpTime;//�W�����v�ŏ㏸���鎞��
    float jampAcc;//�W�����v�̉����x
    bool jampUpPos;//�W�����v�ŏ㏸��
    float maxJampAcc;//�W�����v�̍ő�����x
    float jampFlyTime;//�W�����v���̕��V����
    float maxJampFlyTime;//�W�����v���̍ő啂�V����

    //�}�b�v�̃T�C�Y
    float mapSize;

    //�����l�̐ݒ�Ȃ�
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

    //���b�Ăяo�����
    void Update()
    {
        playerMove();//�v���C���[�̍��E�ړ�
    }

    //�v���C���[�̍��E�ړ�
    void playerMove()
    {
        var hori = Input.GetAxisRaw("Horizontal");//���E�����̓���(���ړ�)

        //���ړ�
        if (hori != 0)
        {
            changeSpriteDir(hori);//�i��ł�������ɉ摜�����킹��
            //�������瓮��
            if (Mathf.Abs(rb.velocity.x) < moveSpeed)
            {
                movePower = hori * moveSpeed;
                rb.AddForce(Vector2.right * movePower);
                stopMove = true;
            }
        }
        else
        {
            //�h���t�g�����h�~�p
            if (stopMove)
            {
                //0�ɂ���Ƃ��܂������܂���B�����炭0�̎��Ƀv���O�����̏������Ԃɍ����Ă��Ȃ�����
                if (Mathf.Abs(rb.velocity.x) > moveSpeed/10)
                {
                    rb.AddForce(Vector2.right * -movePower);
                }
            }
        }
        jamp();//�W�����v�̏���
        rb.position = new Vector2(Mathf.Clamp(rb.position.x,-mapSize,mapSize),rb.position.y);
        moveBackGround.moveBackGround(rb.position.x);
    }


    //�i��ł�������ɉ摜�����킹��
    void changeSpriteDir(float hori)
    {
        if(hori == 1)
        {
            //true�̎��摜�𔽓]������
            sr.flipX = true;
        }
        else
        {
            //false�̎��ɂ��Ƃɖ߂�
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

    //�v���C���[�̃W�����v�̏���
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

    //�����蔻��i�������u�ԁj
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
