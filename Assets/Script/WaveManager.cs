using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    bool begineWave;//�E�F�[�u�����ǂ���
    bool moveText;//wave�̃e�L�X�g���������Ă��邩�ǂ���
    public GameObject WaveCanvasObj;//Wava�̃L�����o�X
    public TextMeshProUGUI waveTextObj;
    RemainEnemy remainEnemy;

    public GameObject bonfire;
    LightBonfire lightBonfire;

    public GameObject enemyGenerate;
    EnemyGenerater enemyGenerater;
    EnemyGenerater2 enemyGenerater2;

    public int enemyNum;

    //�e�L�X�g�̈ʒu
    float textPosX;
    float textStartPosX;
    float textEndPosX;
    float textMidPosX;

    public static int waveCount;//�E�F�[�u�̃J�E���g��
    public static int killEnemy;
    float textMoveSpeed;//�e�L�X�g�̃X�s�[�h
    float textMoveTime;//�e�L�X�g�̎���
    float textStopTime;//�e�L�X�g�̒�~����
    float maxTextStopTime;//�e�L�X�g�̍ő��~����
    bool textStop;//�e�L�X�g����~���Ă��邩�ǂ���
    bool canTextStop;//�e�L�X�g����~�ł��邩�ǂ���
    float textMoveRange;//�e�L�X�g�̓����͈�
    void Start()
    {
        remainEnemy = this.GetComponent<RemainEnemy>();
        enemyGenerater = enemyGenerate.GetComponent<EnemyGenerater>();
        enemyGenerater2 = enemyGenerate.GetComponent<EnemyGenerater2>();
        lightBonfire = bonfire.GetComponent<LightBonfire>();
        begineWave = false;
        moveText = false;
        enemyNum = 10;
        waveCount = 1;
        killEnemy = 0;
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
                enemyGenerater.setNum(enemyNum / 2);
                enemyGenerater2.setNum(enemyNum / 2);
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
        textStop = false;
        canTextStop = true;
    }

    public void endWave()
    {
        if (lightBonfire.bonfireBar.fillAmount > 0)
        {
            begineWave = false;
            waveCount++;
            waveTextObj.text = "Wave" + waveCount;
            enemyNum += 2;
            startWave();
        }
    }

    public bool getBegineWave()
    {
        return this.begineWave;
    }

    public static int getwaveCount()
    {
        return waveCount;
    }
    public static int getKillCount()
    {
        return killEnemy;
    }

    public void addKillCount()
    {
        killEnemy++;
    }
}
