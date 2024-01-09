using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemainEnemy : MonoBehaviour
{
    public WaveManager waveManager;
    public TextMeshProUGUI remainEnemyNumText;

    int remainEnemyNum;

    void Start()
    {
        waveManager = this.GetComponent<WaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waveManager.getBegineWave())
        {
            Debug.Log(remainEnemyNum);
            if (remainEnemyNum == 0)
            {
                waveManager.endWave();
            }
        }
    }

    public void waveSetter(int num)
    {

        this.remainEnemyNum = num;
        remainEnemyNumText.text = "EnemyNum:" + remainEnemyNum;
    }

    public void downEnemyNum()
    {
        if(remainEnemyNum > 0)
        {
            remainEnemyNum--;
        }
        remainEnemyNumText.text = "EnemyNum:" + remainEnemyNum;
    }
}
