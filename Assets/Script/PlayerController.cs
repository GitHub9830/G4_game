using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�ړ��֘A
    float moveSpeed;//�v���C���[�̉��ړ��̑��x
    float movePower;//�v���C���[�̉��ړ��̑��x
    bool stopMove;//�v���C���[�̉��ړ����I��������ǂ���

    Rigidbody2D rb;//�v���C���[��RIgidbody2D������Ƃ���
    SpriteRenderer sr;

    //�W�����v�֘A
    bool canJamp;//�W�����v�ł��邩
    float jampPos;//�W�����v�����n�_
    float maxJampPos;//�W�����v�ł���ō��n�_
    float jampHeight;//�W�����v���鍂��
    float jampUpTime;//�W�����v�ŏ㏸���鎞��
    float jampAcc;//�W�����v�̉����x
    bool jampUpPos;//�W�����v�ŏ㏸��
    float maxJampAcc;//�W�����v�̍ő�����x

    //�����l�̐ݒ�Ȃ�
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
        
        moveSpeed = 5f;
        stopMove = false;

        canJamp = true;
        jampHeight = 1f;
        jampPos = rb.position.y;
        maxJampPos = jampPos + jampHeight;
        jampUpTime = 5f;
        jampAcc = jampHeight / jampUpTime;
        jampUpPos = false;
        maxJampAcc = 10f;
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
        //var vart = Input.GetAxisRaw("Vertical");//���������̓���(�W�����v)

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
                    jampUpPos = false;
                }
                else
                {
                    if(rb.velocity.y < maxJampAcc)
                    {
                        rb.AddForce(Vector2.up * jampAcc, ForceMode2D.Impulse);
                    }
                }
            }
            else
            {
                if (rb.velocity.y > -maxJampAcc)
                {
                    rb.AddForce(Vector2.up * -jampAcc,ForceMode2D.Impulse);
                }
                /*
                if (rb.position.y >= jampPos)
                {
                    rb.AddForce(Vector2.up * -jampAcc);
                }
                else
                {

                }
                */
            }
        }
    }

    //�����蔻��i�������u�ԁj
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJamp = true;
    }
}
