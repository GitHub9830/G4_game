using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed;//�v���C���[�̉��ړ��̑��x
    float movePower;//�v���C���[�̉��ړ��̑��x
    bool stopMove;//�v���C���[�̉��ړ����I��������ǂ���

    Rigidbody2D rb;//�v���C���[��RIgidbody2D������Ƃ���
    SpriteRenderer sr;

    //�����l�̐ݒ�Ȃ�
    void Start()
    {
        moveSpeed = 5f;
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
        stopMove = false;
    }

    //���b�Ăяo�����
    void Update()
    {
        playerMove();
    }

    //�v���C���[�̍��E�ړ�
    void playerMove()
    {
        var hori = Input.GetAxisRaw("Horizontal");//���E�����̓���(���ړ�)
        var vart = Input.GetAxisRaw("Vertical");//���������̓���(�W�����v)

        //���ړ�
        if (hori != 0)
        {
            changeSpriteDir(hori);
            //�������瓮��
            if (rb.velocity.magnitude < moveSpeed)
            {
                movePower = hori * moveSpeed;
                rb.AddForce(new Vector2(movePower, 0));
                stopMove = true;
            }
        }
        else
        {
            //�h���t�g�����h�~�p
            if (stopMove)
            {
                //0�ɂ���Ƃ��܂������܂���B�����炭0�̎��Ƀv���O�����̏������Ԃɍ����Ă��Ȃ�����
                if (rb.velocity.magnitude > 1)
                {
                    rb.AddForce(new Vector2(-movePower, 0));
                }
            }
        }




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
}
