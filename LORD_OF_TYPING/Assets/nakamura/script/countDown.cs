using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class countDown : MonoBehaviour
{
    public float time = 60.0f;//時間
    public TextMeshProUGUI timeText;//表示されるオブジェクト用
    public static bool isTimeUp;//タイムアップ管理用

    void Start()
    {
        isTimeUp = false;
    }

    void Update()
    {
        if (0 < time)
        {
            time -= Time.deltaTime;
            timeText.text = time.ToString("00") +"秒";//表示
        }
        else if (time < 0)isTimeUp = true;//タイムアップ
    }
}
