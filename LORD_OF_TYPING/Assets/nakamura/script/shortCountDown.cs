using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shortCountDown : MonoBehaviour
{
    public float time = 15.0f;//����
    public static bool isTimeUp;//�^�C���A�b�v�Ǘ��p

    void Start()
    {
        isTimeUp = false;
    }

    void Update()
    {
        if(gaugeManager.gauge_flg == 1)//�Q�[�W��1�̎�
        {
            if (0 < time)
            {
                time -= Time.deltaTime;
            }
            else if (time < 0) isTimeUp = true;//�^�C���A�b�v
        }
    }
}
