using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using TMPro;
using UnityEditor;

public class WaveManager : MonoBehaviour
{
    bool begineWave;
    public GameObject WaveCanvasObj;//Wavaのキャンバス
    public TextMeshProUGUI waveTextObj;
    //テキストの位置
    public float textPosX;
    public float textStartPosX;
    public float textEndPosX;
    public float textMidPosX;

    int waveCount;//ウェーブのカウント数
    float textMoveSpeed;//テキストのスピード
    float textMoveTime;//テキストの時間
    float textStopTime;//テキストの停止時間
    float maxTextStopTime;//テキストの最大停止時間
    bool textStop;//テキストが停止しているかどうか
    bool canTextStop;//テキストが停止できるかどうか
    float textMoveRange;//テキストの動く範囲
    void Start()
    {
        begineWave = false;
        waveCount = 1;
        waveTextObj.text = "Wave" + waveCount;
        textMoveTime = 0.5f;
        maxTextStopTime = 1f;
        textStopTime = 1f;
        textMoveRange = 35;
        WaveCanvasObj.SetActive(begineWave);
    }

    void Update()
    {
        textMoveManager();
    }

    void textMoveManager()
    {
        if (begineWave)
        {
            if (waveTextObj.transform.position.x <= textEndPosX)
            {
                begineWave = false;
                WaveCanvasObj.SetActive(begineWave);
            }
            else
            {
                if (canTextStop)
                {
                    textMidPosX = Camera.main.transform.position.x;
                    if (waveTextObj.transform.position.x <= textMidPosX)
                    {
                        textStop = true;
                        canTextStop = false;
                    }
                }
                if (textStop)
                {
                    if (textStopTime >= maxTextStopTime)
                    {
                        textStop = false;
                    }
                    else
                    {
                        textStopTime += Time.deltaTime;
                    }
                }
                else
                {
                    waveTextObj.transform.position -= new Vector3(textMoveSpeed, 0, 0) * Time.deltaTime;
                }
            }
        }
    }

    void startWave()
    {
        float Ppos = Camera.main.transform.position.x;
        textPosX = Ppos + textMoveRange;
        textMoveSpeed = textPosX / textMoveTime;
        textStartPosX = textPosX;
        textEndPosX = -textPosX;
        waveTextObj.transform.position = new Vector2(textStartPosX,0);
        textStopTime = 0;
        textStop = false;
        canTextStop = true;
        begineWave = true;
        WaveCanvasObj.SetActive(begineWave);
    }
}
