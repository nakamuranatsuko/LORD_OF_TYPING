using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class CSVReader : MonoBehaviour
{
    public TextAsset csvFile; // CSVファイル
    public static List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト

    Encoding encoding;

    void Start()
    {
        this.encoding = Encoding.GetEncoding("utf-8");
        csvFile = Resources.Load("CSV_LORD_OF_TYPING_nomalhiragana_UTF-8") as TextAsset; // Resources下のCSV読み込み
        StringReader reader = new StringReader(csvFile.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加
        }
        Debug.Log(csvDatas[1][2]);
    }
}
