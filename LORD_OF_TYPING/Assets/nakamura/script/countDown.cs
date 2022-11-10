using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class countDown : MonoBehaviour
{
    public float time = 60.0f;//����
    public TextMeshProUGUI timeText;//�\�������I�u�W�F�N�g�p
    public static bool isTimeUp;//�^�C���A�b�v�Ǘ��p

    void Start()
    {
        isTimeUp = false;
    }

    void Update()
    {
        if (0 < time)
        {
            time -= Time.deltaTime;
            timeText.text = time.ToString("00") +"�b";//�\��
        }
        else if (time < 0)isTimeUp = true;//�^�C���A�b�v
    }
}
