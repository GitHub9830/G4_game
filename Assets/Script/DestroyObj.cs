using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj: MonoBehaviour
{
    RemainEnemy remainEnemy;
    float time;
    void Start()
    { 
        remainEnemy = GameObject.Find("GameManager").GetComponent<RemainEnemy>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time >= 20f)
        {
            if(this.GetComponent<EnemyGenerater>() != null)
            {
                this.transform.position = this.GetComponent<EnemyGenerater>().spawnPoint;
            }
            else if (this.GetComponent<EnemyGenerater2>() != null)
            {
                this.transform.position = this.GetComponent<EnemyGenerater2>().spawnPoint;
            }
        }
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