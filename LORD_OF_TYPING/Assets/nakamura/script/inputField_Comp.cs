using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class inputField_Comp : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI kanjiText;
    [SerializeField] public TextMeshProUGUI huriganaText;

    public static int score = 0;//�X�R�A�p
    public int scoreNum = 1000;//�X�R�A������

    public static int flg = 0;//������r�Ǘ��p
    public int t_flg = 0;//���������Ǘ��p
    public int firstflg = 0;//�n�߂̗����Ǘ��p
    public int chanFlg = 0;

    public string input;//���͂��ꂽ����
    public int inputLen = 0;//���͂��ꂽ�����̒���

    // InputField��Text�Q�Ɨp
    public TMP_InputField Field;

    public GameObject BG;//�w�i�Ǘ�

    //NomalGame�p
    public int num = 0;//�g�p�����P��̐�
    public int textLen = 201;//CSV���ɂ���P��̐�
    public int rnd = 0;//�����p

    //ShortGame�p
    public int num_s = 0;//�g�p�����P��̐�
    public int textLen_s = 51;//CSV���ɂ���P��̐�
    public int rnd_s = 0;//�����p

    void Start()
    {
        score = 0;//������
    }

    void Update()
    {
        if (countDown.isTimeUp == false)//�^�C���A�b�v����Ȃ����
        {
            if (chanFlg == 0) NomalGame();
            else
            {
                if (shortCountDown.isTimeUp == false) ShortGame();
                else chanFlg = 0;//�`�F���W�t���O��0�ɂ���
                
            }
        }
        else StartCoroutine("TimeUp");//�R���[�`���̎��s
    }

    void NomalGame()
    {
        BG.SetActive(true);//�\��

        int wordLen = textLen - num;

        if (firstflg == 0)
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

        flg = KanaComp(huriganaText.text);//������r

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
            score += scoreNum;//�X�R�A�𑫂�
            t_flg = 1;//�����_��������L���ɂ���
            Field.GetComponent<TMP_InputField>().text = "";//�󔒂ɂ���

            if (gaugeManager.gauge_flg == 1)
            {
                chanFlg = 1;
                kanjiText.text = "";
                huriganaText.text = "";
            }
        }
    }

    void ShortGame()
    {
        BG.SetActive(false);//��\��

        if (shortCountDown.isTimeUp == false)
        {
            int wordLen_short = textLen_s - num_s;

            if (t_flg == 1)
            {
                //�����_������
                rnd_s = Random.Range(1, wordLen_short);
                //�\��
                kanjiText.text = CSV_short.csvDatas[rnd_s][1];
                huriganaText.text = CSV_short.csvDatas[rnd_s][2];

                t_flg = 0;//�����_�������𖳌��ɂ���
            }

            flg = KanaComp(huriganaText.text);//������r

            //������r�������Ă����
            if (flg == 1)
            {
                //rnd_s�̌��t���㏑�������(�������)
                for (int i = 1; i < wordLen_short - 1; i++)
                {
                    if (i >= rnd_s)
                    {
                        CSV_short.csvDatas[i][1] = CSV_short.csvDatas[i + 1][1];
                        CSV_short.csvDatas[i][2] = CSV_short.csvDatas[i + 1][2];
                    }
                }
                num_s++;
                score += scoreNum;//�X�R�A�𑫂�
                t_flg = 1;//�����_��������L���ɂ���
                Field.GetComponent<TMP_InputField>().text = "";//�󔒂ɂ���
            }
        }
        else chanFlg = 0;//�`�F���W�t���O��0�ɂ���
            
    }

    public void OnValueChanged()//���A���^�C���ŕ����̎擾
    {
        input = Field.GetComponent<TMP_InputField>().text;//���͂��ꂽ�������i�[
        inputLen = input.Length;//��r������͂��ꂽ�����̒����̎擾
    }

    int KanaComp(string moji)
    {
        int kanaflg = 0;
        int kanaLen = moji.Length;//��r�������t���K�i�̒������擾
        if (inputLen == kanaLen)
        {
            for (int i = 0; i < kanaLen; i++)
            {
                if (input[i] != moji[i])
                {
                    kanaflg = 0;
                    break;
                }
                else kanaflg = 1;
            }
        }
        return kanaflg;
    }

    private IEnumerator TimeUp()
    {
        //3�b�҂�
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("result", LoadSceneMode.Single);
    }
}
