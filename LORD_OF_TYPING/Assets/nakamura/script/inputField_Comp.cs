using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System.Text;
using UnityEngine.UI;

public class inputField_Comp : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI kanjiText;
    [SerializeField] public TextMeshProUGUI huriganaText;

    public int num = 0;//�g�p�����P��̐�
    public int textLen = 201;//CSV���ɂ���P��̐�
    public int rnd = 0;//�����p
    public int flg = 0;//������r�Ǘ��p
    public int t_flg = 0;//���������Ǘ��p
    public int firstflg = 0;//�n�߂̗����Ǘ��p

    public string input;
    public int inputLen = 0;

    // InputField��Text�Q�Ɨp
    public TMP_InputField Field;

    void Update()
    {
        int wordLen = textLen - num;

        if(firstflg == 0)
        {
            //�����_������
            rnd = Random.Range(1, textLen);
            //�\��
            kanjiText.text = CSVReader.csvDatas[rnd][1];
            huriganaText.text = CSVReader.csvDatas[rnd][2];

            firstflg = 1;//�����ɂ���
            Field.Select();//�t�H�[�J�X����
        }

        if (t_flg == 1)
        {
            //�����_������
            rnd = Random.Range(1, wordLen);
            //�\��
            kanjiText.text = CSVReader.csvDatas[rnd][1];
            huriganaText.text = CSVReader.csvDatas[rnd][2];

            t_flg = 0;//�����_�������𖳌��ɂ���
        }
        flg = KanaComp(rnd);
        //������r�������Ă����
        if (flg == 1)
        {
            //rnd�̌��t���㏑�������(�������)
            for (int i = 1; i < wordLen - 1; i++)
            {
                if (i >= rnd)
                {
                    CSVReader.csvDatas[i][1] = CSVReader.csvDatas[i + 1][1];
                    CSVReader.csvDatas[i][2] = CSVReader.csvDatas[i + 1][2];
                }
            }
            num++;
            t_flg = 1;//�����_��������L���ɂ���
            Field.GetComponent<TMP_InputField>().text = "";//�󔒂ɂ���
        }

        if (wordLen == 0) UnityEditor.EditorApplication.isPaused = true;//�ꎞ��~
    }

    public void OnValueChanged()//���A���^�C���ŕ����̎擾
    {
        input = Field.GetComponent<TMP_InputField>().text;//���͂��ꂽ�������i�[
        inputLen = input.Length;//��r������͂��ꂽ�����̒����̎擾
    }

    int KanaComp(int rnd)
    {
        int kanaflg = 0;
        string kana = CSVReader.csvDatas[rnd][2];//�t���K�i�̎擾
        int kanaLen = kana.Length;//��r�������t���K�i�̒������擾
        if (inputLen == kanaLen)
        {
            for (int i = 0; i < kanaLen; i++)
            {
                if (input[i] != kana[i])
                {
                    kanaflg = 0;
                    break;
                }
                else kanaflg = 1;
            }
        }
        return kanaflg;
    }
}
