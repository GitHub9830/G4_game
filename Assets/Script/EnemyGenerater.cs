using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater: MonoBehaviour
{    public GameObject enemy;

    int num = 0;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        num++;
        if (num % 250 == 0)
        {
            Instantiate(enemy, new Vector3(-24,-3,0), Quaternion.identity);

        }

    }
}