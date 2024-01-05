using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBonfire : MonoBehaviour
{
    bool lightBonfire;//���΂��_���Ă��邩�ǂ���
    float lightTime;//���΂̓_������
    float maxLightTime;//���΂̓_���ő厞��

    //���΂̐F
    Color lightOn;//�_���Ă���
    Color lightOff;//�_���Ă��Ȃ�

    float addTimeScale;//���΂̒ǉ��_������


    SpriteRenderer bonfireSR;//���΂�SpriteRenderer

    //���̃X�N���v�g�ŕ��΂��_���Ă��邩���擾����Ƃ��ɌĂяo���Ă�������
    public bool getLightBonfire()
    {
        return lightBonfire;
    }

    //���̃X�N���v�g�ŕ��΂̌��ʎ��Ԃ�L�΂������Ƃ��ɌĂяo���Ă�������
    public void addLightTime()
    {
        if(lightTime < maxLightTime)lightTime += addTimeScale;
    }

    //�����l�̐ݒ�Ȃ�
    void Start()
    {
        bonfireSR = this.GetComponent<SpriteRenderer>();

        lightBonfire = false;
        lightTime = 2;
        maxLightTime = 10;
        lightOn = new Color(1.0f, 0, 0);
        lightOff = new Color(1.0f, 1.0f, 1.0f);
        addTimeScale = 1;
    }

    void Update()
    {
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
        if (lightTime > 0)
        {
            //0�ȏ�̎��͓_��
            if (!lightBonfire) lightBonfire = true;
            lightTime -= Time.deltaTime;
        }
        else
        {
            //0�ȉ��̎��͏���
            if (lightBonfire)
            {
                lightBonfire = false;
                lightTime = 0;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            addLightTime();//���΂̎��Ԓǉ�
            Debug.Log("addTime");
        }
    }
}
