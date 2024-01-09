using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemainEnemy : MonoBehaviour
{
    public WaveManager waveManager;
    public TextMeshProUGUI remainEnemyNumText;

    public bool changeEnemyNum;
    public int remainEnemyNum;

    void Start()
    {
        waveManager = this.GetComponent<WaveManager>();
        remainEnemyNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (waveManager.getBegineWave())
        {
            if (remainEnemyNum == 0)
            {
                waveManager.endWave();
            }
        }
    }

    public void waveSetter(int num)
    {

        remainEnemyNum = num;
        remainEnemyNumText.text = "EnemyNum:" + remainEnemyNum;
    }

    public void downEnemyNum()
    {
        remainEnemyNum--;
        remainEnemyNumText.text = "EnemyNum:" + remainEnemyNum;
    }
}
