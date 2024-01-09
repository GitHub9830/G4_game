using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater2 : MonoBehaviour
{
    public GameObject enemy2;

    int num = 0;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        num++;
        if (num % 290 == 0)
        {
            Instantiate(enemy2, new Vector3(18,-3,0), Quaternion.identity);

        }

    }
}