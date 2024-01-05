using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBonfire : MonoBehaviour
{
    bool lightBonfire;//焚火が点いているかどうか
    float lightTime;

    //焚火の色
    Color lightOn;//点いている
    Color lightOff;//点いていない


    SpriteRenderer bonfireSR;//焚火のSpriteRenderer

    //他のスクリプトで焚火が点いているかを取得するときに呼び出してください
    public bool getLightBonfire()
    {
        return lightBonfire;
    }

    //初期値の設定など
    void Start()
    {
        bonfireSR = this.GetComponent<SpriteRenderer>();

        lightBonfire = false;
        lightTime = 2;
        lightOn = new Color(1.0f, 0, 0);
        lightOff = new Color(1.0f, 1.0f, 1.0f);
    }

    void Update()
    {
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
        if(lightTime > 0)
        {
            if(!lightBonfire)lightBonfire = true;
            lightTime -= Time.deltaTime;
        }
        else
        {
            if(lightBonfire)lightBonfire = false;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
