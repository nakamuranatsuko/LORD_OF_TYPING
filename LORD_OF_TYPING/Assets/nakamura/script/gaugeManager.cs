using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gaugeManager : MonoBehaviour
{
    public Image gauge;//�Q�[�W�摜
    public int gaugeTime = 30;//�Q�[�W�Ǘ��p
    public int input_success = 15;//�^�C�s���O�������̃Q�[�W������
    public static int gauge_flg = 0;//�Q�[�W�����ׂĖ��܂������p
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
            gaugeTime -= 1;//�Q�[�W��1����
        }
        if(inputField_Comp.flg == 1) gaugeTime += input_success;//�Q�[�W�𑝂₷
        num = gaugeTime / 100.0f;
        gauge.fillAmount = num;//�Q�[�W�ɔ��f������
        if(gauge.fillAmount >= 1) gauge_flg = 1;//�Q�[�W��1�ɂȂ�����t���O�𗧂�����
    }
}
