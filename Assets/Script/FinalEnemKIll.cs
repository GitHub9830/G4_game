using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalEnemKIll : MonoBehaviour
{
    public TextMeshProUGUI FScore;
    public int fEnemyKill;

    void Start()
    {
        fEnemyKill = WaveManager.getKillCount();
        FScore.text = "KillEnemy: 0";
    }

    // Update is called once per frame
    void Update()
    {
        FScore.text = "KillEnemy:" + fEnemyKill;
    }
}
