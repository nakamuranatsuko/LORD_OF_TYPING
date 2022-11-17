using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gaugeManager : MonoBehaviour
{
    public Image gauge;//ゲージ画像
    public int gaugeTime = 30;//ゲージ管理用
    public int input_success = 15;//タイピング成功時のゲージ増加数
    public static int gauge_flg = 0;//ゲージがすべて埋まった時用
    public float num = 0;

    public float time;

    void Start()
    {
        gauge_flg = 0;
    }

    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0.0)
        {
            time = 1.0f;
            gaugeTime -= 1;//ゲージが1減る
        }
        if(inputField_Comp.flg == 1) gaugeTime += input_success;//ゲージを増やす
        num = gaugeTime / 100.0f;
        gauge.fillAmount = num;//ゲージに反映させる
        if(gauge.fillAmount >= 1) gauge_flg = 1;//ゲージが1になったらフラグを立たせる
    }
}
