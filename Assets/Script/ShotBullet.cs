using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InsBullet();
        }
    }

    void InsBullet()
    {
        Instantiate(bullet,spawnPoint.transform.position,Quaternion.identity);
    }
}
