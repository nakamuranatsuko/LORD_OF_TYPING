using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gaugeManager : MonoBehaviour
{
    public Image gauge;//�Q�[�W�摜
    public static int gaugeTime = 30;//�Q�[�W�Ǘ��p

    public float time;

    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0.0)
        {
            time = 1.0f;
            gaugeManager.gaugeTime -= 1;//�Q�[�W��1����
        }
        if (inputField_Comp.flg == 1) gaugeManager.gaugeTime += 5;//�Q�[�W��5������
        gauge.fillAmount = gaugeTime / 100.0f;//�Q�[�W�ɔ��f������
    }
}
