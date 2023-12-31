using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LightBonfire : MonoBehaviour
{
    public Image bonfireBar;//焚火の燃える時間
    bool lightBonfire;//焚火が点いているかどうか

    float maxLightTime;

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
            bonfireBar.fillAmount += upSpeed / maxLightTime;
        }
    }

    //初期値の設定など
    void Start()
    {
        lightBonfire = false;

        maxLightTime = 10f;
    }

    void Update()
    {
        bonfireTimer();//焚火の時間計測
        if (!lightBonfire)
        {
            SceneManager.LoadScene("GameENDScene");
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

    public void downBonfireTime(float downSpeed)
    {
        if(bonfireBar.fillAmount > 0)
        {
            bonfireBar.fillAmount -= downSpeed / maxLightTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))//ここのタグを敵にすること(Playerなのは動作確認用)
        {
            bonfireBar.fillAmount -= 0.1f;//個々の数値を調整してゲージの減り幅を調節
        }
    }
}
