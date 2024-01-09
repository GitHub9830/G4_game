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
            bonfireBar.fillAmount += (upSpeed / maxLightTime);
        }
    }

    //�����l�̐ݒ�Ȃ�
    void Start()
    {
        bonfireSR = this.GetComponent<SpriteRenderer>();

        lightBonfire = false;
        lightOn = new Color(1.0f, 0, 0);
        lightOff = new Color(1.0f, 1.0f, 1.0f);

        maxLightTime = 10f;
    }

    void Update()
    {
        Debug.Log(bonfireBar.fillAmount);
        Debug.Log(1 / maxLightTime);
        if (Input.GetKeyDown(KeyCode.U))
        {
            downBonfireTime(2);
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
            bonfireBar.fillAmount -= (downSpeed / maxLightTime);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {

    }
}
