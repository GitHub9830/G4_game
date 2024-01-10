using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�ړ��֘A
    float moveSpeed;//�v���C���[�̉��ړ��̑��x
    float movePower;//�v���C���[�̉��ړ��̑��x
    bool stopMove;//�v���C���[�̉��ړ����I��������ǂ���
    public float saveHori;

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

    float time;

    //�����l�̐ݒ�Ȃ�
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sr = playerSprite.GetComponent<SpriteRenderer>();
        moveBackGround = background.GetComponent<MoveBackGround>();
        
        moveSpeed = 8f;
        stopMove = false;

        canJamp = true;
        jampHeight = 3;
        jampPos = rb.position.y;
        maxJampPos = jampPos + jampHeight;
        jampUpTime = 0.1f;
        jampAcc = jampHeight / jampUpTime;
        jampUpPos = false;
        maxJampAcc = jampAcc * 2;
        jampFlyTime = 0;
        maxJampFlyTime = 0.1f;

        mapSize = 20;

        time = 0;
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
        var vart = Input.GetAxisRaw("Vertical");//������̓���(�W�����v)

        //���ړ�
        if (hori != 0)
        {
            saveHori = hori;
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
                time += Time.deltaTime;
                //0�ɂ���Ƃ��܂������܂���B�����炭0�̎��Ƀv���O�����̏������Ԃɍ����Ă��Ȃ�����
                if (Mathf.Abs(rb.velocity.x) > moveSpeed/10)
                {
                    rb.AddForce(Vector2.right * -movePower);
                }
                else
                {
                    stopMove = false;
                }

                if(time >= 1f)
                {
                    if (rb.velocity.x != 0)
                    {
                        rb.velocity = new Vector2(0, 0);
                        time = 0;
                        stopMove = false;
                    }
                }
            }
        }
        goDown();//�W�����v������Ȃ��Ƃ��̗���
        jamp(vart);//�W�����v�̏���
        this.transform.position = new Vector2(Mathf.Clamp(this.transform.position.x,-mapSize,mapSize),this.transform.position.y);//�v���C���[�̓�����͈�
        moveBackGround.moveBackGround(rb.position);//�w�i�̈ړ�
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

    //�W�����v������Ȃ��Ƃ��̗���
    void goDown()
    {
        if (!canJamp) return;
        if(rb.velocity.y != 0)
        {
            if (rb.velocity.y > -maxJampAcc)
            {
                rb.AddForce(Vector2.up * -jampAcc);
            }
        }
    }

    //�v���C���[�̃W�����v�̏���
    void jamp(float vart)
    {
        if (canJamp)
        {
            if (vart == 1)
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
    }
}
