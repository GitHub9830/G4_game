using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightBonfire : MonoBehaviour
{
    public Image bonfireBar;//���΂̔R���鎞��
    bool lightBonfire;//���΂��_���Ă��邩�ǂ���

    //���΂̐F
    Color lightOn;//�_���Ă���
    Color lightOff;//�_���Ă��Ȃ�

    float maxLightTime;

    SpriteRenderer bonfireSR;//���΂�SpriteRenderer

    //���̃X�N���v�g�ŕ��΂��_���Ă��邩���擾����Ƃ��ɌĂяo���Ă�������
    public bool getLightBonfire()
    {
        return lightBonfire;
    }

    //���̃X�N���v�g�ŕ��΂̌��ʎ��Ԃ�L�΂������Ƃ��ɌĂяo���Ă�������
    public void addLightTime(float upSpeed)
    {
        if(bonfireBar.fillAmount < 1)
        {
<<<<<<< HEAD
            bonfireBar.fillAmount += (upSpeed / maxLightTime) * Time.deltaTime;
=======
            bonfireBar.fillAmount += (upSpeed / maxLightTime);
>>>>>>> d41bbae1cf0251dc9afa23a428ad81fa15463740
        }
    }

    //�����l�̐ݒ�Ȃ�
    void Start()
    {
        bonfireSR = this.GetComponent<SpriteRenderer>();

        lightBonfire = false;
        lightOn = new Color(1.0f, 0, 0);
        lightOff = new Color(1.0f, 1.0f, 1.0f);
<<<<<<< HEAD
        bonfireBar.fillAmount = 1;
=======

        maxLightTime = 10f;
>>>>>>> d41bbae1cf0251dc9afa23a428ad81fa15463740
    }

    void Update()
    {
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.U))
        {
            downBonfireTime(1);
=======
        Debug.Log(bonfireBar.fillAmount);
        Debug.Log(1 / maxLightTime);
        if (Input.GetKeyDown(KeyCode.U))
        {
            downBonfireTime(2);
>>>>>>> d41bbae1cf0251dc9afa23a428ad81fa15463740
        }
        bonfireTimer();//���΂̎��Ԍv��
        if (lightBonfire)
        {
            bonfireSR.color = lightOn;
        }
        else
        {
            bonfireSR.color = lightOff;
        }
    }

    //���΂̎��Ԍv��
    void bonfireTimer()
    {
        if (bonfireBar.fillAmount > 0)
        {
            //0�ȏ�̎��͓_��
            if (!lightBonfire) lightBonfire = true;
        }
        else
        {
            //0�ȉ��̎��͏���
            if (lightBonfire)
            {
                bonfireBar.fillAmount = 0;
                lightBonfire = false;
            }
        }
    }

    void downBonfireTime(float downSpeed)
    {
        if(bonfireBar.fillAmount > 0)
        {
<<<<<<< HEAD
            bonfireBar.fillAmount -= (downSpeed / maxLightTime) * Time.deltaTime;
=======
            bonfireBar.fillAmount -= (downSpeed / maxLightTime);
>>>>>>> d41bbae1cf0251dc9afa23a428ad81fa15463740
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {

    }
}
