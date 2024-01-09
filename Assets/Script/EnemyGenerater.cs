using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater: MonoBehaviour
{    public GameObject enemy;

    int num;
    int maxNum;
    float time;
    float maxTime;

    void Start()
    {
        maxTime = 2.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(num <= maxNum)
        {
            time += Time.deltaTime;
            if (time >= maxTime)
            {
                Instantiate(enemy, new Vector3(-24, -3, 0), Quaternion.identity);
                num++;
                time = 0;
            }
        }
    }

    public void setNum(int num)
    {
        this.num = 1;
        this.maxNum = num;
        maxTime *= 0.9f;
    }
}