using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gaugeManager : MonoBehaviour
{
    public Image gauge;//ゲージ画像
    public static int gaugeTime = 30;//ゲージ管理用

    public float time;

    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0.0)
        {
            time = 1.0f;
            gaugeManager.gaugeTime -= 1;//ゲージが1減る
        }
        if (inputField_Comp.flg == 1) gaugeManager.gaugeTime += 5;//ゲージが5増える
        gauge.fillAmount = gaugeTime / 100.0f;//ゲージに反映させる
    }
}
