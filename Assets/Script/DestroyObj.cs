using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj: MonoBehaviour
{
    RemainEnemy remainEnemy;
    void Start()
    { 
        remainEnemy = GameObject.Find("GameManager").GetComponent<RemainEnemy>();
    }

    void Update()
    {

    }

 
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bonfire"))//����������Tagutukeru�Ƃ����^�O������I�u�W�F�N�g����Ł`�Ƃ��������̉�
        {
            Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
            remainEnemy.downEnemyNum();
        }
    }
}