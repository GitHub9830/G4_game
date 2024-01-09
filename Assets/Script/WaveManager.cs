using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    bool begineWave;//ウェーブ中かどうか
    bool moveText;//waveのテキストがうごいているかどうか
    public GameObject WaveCanvasObj;//Wavaのキャンバス
    public TextMeshProUGUI waveTextObj;
    RemainEnemy remainEnemy;

    public GameObject enemyGenerate;
    EnemyGenerater enemyGenerater;
    EnemyGenerater2 enemyGenerater2;

    public int enemyNum;

    //テキストの位置
    float textPosX;
    float textStartPosX;
    float textEndPosX;
    float textMidPosX;

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
        remainEnemy = this.GetComponent<RemainEnemy>();
        enemyGenerater = enemyGenerate.GetComponent<EnemyGenerater>();
        enemyGenerater2 = enemyGenerate.GetComponent<EnemyGenerater2>();
        begineWave = false;
        moveText = false;
        enemyNum = 10;
        waveCount = 1;
        waveTextObj.text = "Wave" + waveCount;
        textMoveTime = 0.5f;
        maxTextStopTime = 1f;
        textStopTime = 1f;
        textMoveRange = 35;
        startWave();
    }

    void Update()
    {
        textMoveManager();
    }

    void textMoveManager()
    {
        if (moveText)
        {
            if (waveTextObj.transform.position.x <= textEndPosX)
            {
                moveText = false;
                WaveCanvasObj.SetActive(moveText);
                remainEnemy.waveSetter(enemyNum);
                begineWave = true;
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

    public void startWave()
    {
        moveText = true;
        WaveCanvasObj.SetActive(moveText);
        float Ppos = Camera.main.transform.position.x;
        textPosX = Ppos + textMoveRange;
        textMoveSpeed = textPosX / textMoveTime;
        textStartPosX = textPosX;
        textEndPosX = -textPosX;
        waveTextObj.transform.position = new Vector2(textStartPosX,0);
        textStopTime = 0;
        enemyGenerater.setNum(enemyNum/2);
        enemyGenerater2.setNum(enemyNum/2);
        textStop = false;
        canTextStop = true;
    }

    public void endWave()
    {
        begineWave = false;
        waveCount++;
        waveTextObj.text = "Wave" + waveCount;
        enemyNum += 2;
        startWave();
    }

    public bool getBegineWave()
    {
        return this.begineWave;
    }
}
