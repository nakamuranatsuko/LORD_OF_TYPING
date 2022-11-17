using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class CSVReader : MonoBehaviour
{
    public TextAsset csvFile; // CSV�t�@�C��
    public static List<string[]> csvDatas = new List<string[]>(); // CSV�̒��g�����郊�X�g

    Encoding encoding;

    void Start()
    {
        this.encoding = Encoding.GetEncoding("utf-8");
        csvFile = Resources.Load("CSV_LORD_OF_TYPING_nomalhiragana_UTF-8") as TextAsset; // Resources����CSV�ǂݍ���
        StringReader reader = new StringReader(csvFile.text);

        // , �ŕ�������s���ǂݍ���
        // ���X�g�ɒǉ����Ă���
        while (reader.Peek() != -1) // reader.Peek��-1�ɂȂ�܂�
        {
            string line = reader.ReadLine(); // ��s���ǂݍ���
            csvDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�
        }
        Debug.Log(csvDatas[1][2]);
    }
}
