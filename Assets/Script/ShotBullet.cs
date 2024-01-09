using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject bullet;

    float time;

    // Update is called once per frame
    void Update()
    {
        if(time >= 2f)
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

    void InsBullet()
    {
        Instantiate(bullet,spawnPoint.transform.position,Quaternion.identity);
    }
}
