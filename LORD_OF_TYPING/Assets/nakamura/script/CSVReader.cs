using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System.Text;

public class CSVReader : MonoBehaviour
{
    TextAsset csvFile; // CSV�t�@�C��
    List<string[]> csvDatas = new List<string[]>(); // CSV�̒��g�����郊�X�g;

    [SerializeField] public TextMeshProUGUI kanjiText;
    [SerializeField] public TextMeshProUGUI huriganaText;

    Encoding encoding;

    [SerializeField] private float _timeInterval;
    private float _timeElapsed = 0;

    public int num = 0;
    public int textLen = 201;

    void Start()
    {

        this.encoding = Encoding.GetEncoding("utf-8");
        csvFile = Resources.Load("CSV_LORD_OF_TYPING_nomal_UTF-8") as TextAsset; // Resources����CSV�ǂݍ���
        StringReader reader = new StringReader(csvFile.text);

        // , �ŕ�������s���ǂݍ���
        // ���X�g�ɒǉ����Ă���
        while (reader.Peek() != -1) // reader.Peek��-1�ɂȂ�܂�
        {
            string line = reader.ReadLine(); // ��s���ǂݍ���
            csvDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�
        }


        // csvDatas[�s][��]���w�肵�Ēl�����R�Ɏ��o����
        //Debug.Log(csvDatas[0][1]);
        //txt.text = csvDatas[1][1];

    }

    void Update()
    {
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed > _timeInterval)
        {
            //�����_������
            int rnd = Random.Range(1, textLen - num);
            //�\��
            kanjiText.text = csvDatas[rnd][1];
            huriganaText.text = csvDatas[rnd][2];

            Debug.Log(csvDatas[rnd][1]);
            Debug.Log(csvDatas[rnd][2]);

            //rnd�̌��t���㏑�������(�������)
            for (int i = 1; i < textLen - num - 1; i++)
            {
                if(i >= rnd)
                {
                    csvDatas[i][1] = csvDatas[i + 1][1];
                    csvDatas[i][2] = csvDatas[i + 1][2];
                }
            }
            num++;
            Debug.Log(textLen - num);
            if (textLen == 0) UnityEditor.EditorApplication.isPaused = true;//�ꎞ��~

            // �o�ߎ��Ԃ����ɖ߂�
            _timeElapsed = 0f;
        }
    }
}
