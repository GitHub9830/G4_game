using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightBonfire : MonoBehaviour
{
    public Image bonfireBar;//焚火の燃える時間
    bool lightBonfire;//焚火が点いているかどうか

    //焚火の色
    Color lightOn;//点いている
    Color lightOff;//点いていない

    float maxLightTime;

    SpriteRenderer bonfireSR;//焚火のSpriteRenderer

    //他のスクリプトで焚火が点いているかを取得するときに呼び出してください
    public bool getLightBonfire()
    {
        return lightBonfire;
    }

    //他のスクリプトで焚火の効果時間を伸ばしたいときに呼び出してください
    public void addLightTime(float upSpeed)
    {
        if(bonfireBar.fillAmount < 1)
        {
            bonfireBar.fillAmount += (upSpeed / maxLightTime);
        }
    }

    //初期値の設定など
    void Start()
    {
        bonfireSR = this.GetComponent<SpriteRenderer>();

        lightBonfire = false;
        lightOn = new Color(1.0f, 0, 0);
        lightOff = new Color(1.0f, 1.0f, 1.0f);

        maxLightTime = 10f;
    }

    void Update()
    {
        Debug.Log(bonfireBar.fillAmount);
        Debug.Log(1 / maxLightTime);
        if (Input.GetKeyDown(KeyCode.U))
        {
            downBonfireTime(2);
        }
        bonfireTimer();//焚火の時間計測
        if (lightBonfire)
        {
            bonfireSR.color = lightOn;
        }
        else
        {
            bonfireSR.color = lightOff;
        }
    }

    //焚火の時間計測
    void bonfireTimer()
    {
        if (bonfireBar.fillAmount > 0)
        {
            //0以上の時は点灯
            if (!lightBonfire) lightBonfire = true;
        }
        else
        {
            //0以下の時は消灯
            if (lightBonfire)
            {
                bonfireBar.fillAmount = 0;
                lightBonfire = false;
            }
        }
    }

    void downBonfireTime(float downSpeed)
    {
        if(bonfireBar.fillAmount > 0)
        {
            bonfireBar.fillAmount -= (downSpeed / maxLightTime);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {

    }
}
