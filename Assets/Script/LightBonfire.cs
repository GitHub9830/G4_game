using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBonfire : MonoBehaviour
{
    bool lightBonfire;//���΂��_���Ă��邩�ǂ���
    float lightTime;

    //���΂̐F
    Color lightOn;//�_���Ă���
    Color lightOff;//�_���Ă��Ȃ�


    SpriteRenderer bonfireSR;//���΂�SpriteRenderer

    //���̃X�N���v�g�ŕ��΂��_���Ă��邩���擾����Ƃ��ɌĂяo���Ă�������
    public bool getLightBonfire()
    {
        return lightBonfire;
    }

    //�����l�̐ݒ�Ȃ�
    void Start()
    {
        bonfireSR = this.GetComponent<SpriteRenderer>();

        lightBonfire = false;
        lightTime = 2;
        lightOn = new Color(1.0f, 0, 0);
        lightOff = new Color(1.0f, 1.0f, 1.0f);
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
        if(lightTime > 0)
        {
            if(!lightBonfire)lightBonfire = true;
            lightTime -= Time.deltaTime;
        }
        else
        {
            if(lightBonfire)lightBonfire = false;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
