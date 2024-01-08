using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    bool begineWave;
    public GameObject WaveCanvasObj;//Wavaのキャンバス
    public TextMeshProUGUI waveTextObj;
    public float textPosX;
    public Vector2 textStartPos;
    public Vector2 textEndPos;
    int waveCount;//ウェーブのカウント数
    float textMoveSpeed;

    void Start()
    {
        begineWave = false;
        waveCount = 1;
        waveTextObj.text = "Wave" + waveCount;
        textPosX = 800;
        textMoveSpeed = 50f;
        textStartPos = new Vector2(textPosX,0);
        textEndPos = new Vector2(-textPosX, 0);
        WaveCanvasObj.SetActive(begineWave);
    }

    void Update()
    {
        if(begineWave)
        {
            if(waveTextObj.transform.position.x <= textEndPos.x)
            {

            }
            else
            {

            }
        }
    }

    void startWave()
    {
        waveTextObj.transform.position = textStartPos;
        begineWave = true;
        WaveCanvasObj.SetActive(begineWave);
    }
}
