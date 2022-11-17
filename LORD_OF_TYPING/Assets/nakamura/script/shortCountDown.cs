using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shortCountDown : MonoBehaviour
{
    public float time = 15.0f;//時間
    public static bool isTimeUp;//タイムアップ管理用

    void Start()
    {
        isTimeUp = false;
    }

    void Update()
    {
        if(gaugeManager.gauge_flg == 1)//ゲージが1の時
        {
            if (0 < time)
            {
                time -= Time.deltaTime;
            }
            else if (time < 0) isTimeUp = true;//タイムアップ
        }
    }
}
