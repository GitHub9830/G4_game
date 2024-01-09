using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalWave : MonoBehaviour
{

    public TextMeshProUGUI FScore;
    public int fWave;

    void Start()
    {
        fWave = WaveManager.getwaveCount();
        FScore.text = "Wave: 0";
    }

    // Update is called once per frame
    void Update()
    {
        FScore.text = "Wave:" + fWave;
    }
}
