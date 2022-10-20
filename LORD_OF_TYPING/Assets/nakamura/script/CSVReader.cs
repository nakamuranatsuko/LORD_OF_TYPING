using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System.Text;

public class CSVReader : MonoBehaviour
{
    TextAsset csvFile; // CSVファイル
    List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト;

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
        csvFile = Resources.Load("CSV_LORD_OF_TYPING_nomal_UTF-8") as TextAsset; // Resources下のCSV読み込み
        StringReader reader = new StringReader(csvFile.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加
        }


        // csvDatas[行][列]を指定して値を自由に取り出せる
        //Debug.Log(csvDatas[0][1]);
        //txt.text = csvDatas[1][1];

    }

    void Update()
    {
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed > _timeInterval)
        {
            //ランダム生成
            int rnd = Random.Range(1, textLen - num);
            //表示
            kanjiText.text = csvDatas[rnd][1];
            huriganaText.text = csvDatas[rnd][2];

            Debug.Log(csvDatas[rnd][1]);
            Debug.Log(csvDatas[rnd][2]);

            //rndの言葉が上書きされる(消される)
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
            if (textLen == 0) UnityEditor.EditorApplication.isPaused = true;//一時停止

            // 経過時間を元に戻す
            _timeElapsed = 0f;
        }
    }
}
