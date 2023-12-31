using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater2 : MonoBehaviour
{
    public GameObject enemy2;

    int num;
    int maxNum;
    float time;
    float maxTime;

    void Start()
    {
        maxTime = 2.4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (num < maxNum)
        {
            time += Time.deltaTime;
            if (time >= maxTime)
            {
                Instantiate(enemy2, new Vector3(18, -3, 0), Quaternion.identity);
                num++;
                time = 0;
            }
        }
    }

    public void setNum(int num)
    {
        this.num = 0;
        this.maxNum = num;
        maxTime *= 0.9f;
    }
}