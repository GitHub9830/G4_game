using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject bullet;

    float time;
    int nowBulletNum;
    int maxBulletNum;

    void Start()
    {
        maxBulletNum = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(nowBulletNum < maxBulletNum)
        {
            if (time >= 0.5f)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    InsBullet();
                    time = 0;
                }
            }
            else
            {
                time += Time.deltaTime;
            }
        }
    }

    public void addBulletNum()
    {
        nowBulletNum++;
    }

    public void disBulletNum()
    {
        nowBulletNum--;
    }

    void InsBullet()
    {
        Instantiate(bullet,spawnPoint.transform.position,Quaternion.identity);
    }
}
