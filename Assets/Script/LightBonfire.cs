using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBonfire : MonoBehaviour
{
    bool lightBonfire;//焚火が点いているかどうか
    float lightTime;//焚火の点灯時間
    float maxLightTime;//焚火の点灯最大時間

    //焚火の色
    Color lightOn;//点いている
    Color lightOff;//点いていない

    float addTimeScale;//焚火の追加点灯時間


    SpriteRenderer bonfireSR;//焚火のSpriteRenderer

    //他のスクリプトで焚火が点いているかを取得するときに呼び出してください
    public bool getLightBonfire()
    {
        return lightBonfire;
    }

    //他のスクリプトで焚火の効果時間を伸ばしたいときに呼び出してください
    public void addLightTime()
    {
        if(lightTime < maxLightTime)lightTime += addTimeScale;
    }

    //初期値の設定など
    void Start()
    {
        bonfireSR = this.GetComponent<SpriteRenderer>();

        lightBonfire = false;
        lightTime = 2;
        maxLightTime = 10;
        lightOn = new Color(1.0f, 0, 0);
        lightOff = new Color(1.0f, 1.0f, 1.0f);
        addTimeScale = 1;
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
        if (lightTime > 0)
        {
            //0以上の時は点灯
            if (!lightBonfire) lightBonfire = true;
            lightTime -= Time.deltaTime;
        }
        else
        {
            //0以下の時は消灯
            if (lightBonfire)
            {
                lightBonfire = false;
                lightTime = 0;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            addLightTime();//焚火の時間追加
            Debug.Log("addTime");
        }
    }
}
