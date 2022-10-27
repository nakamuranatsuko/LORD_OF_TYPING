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

    public int num = 0;//使用した単語の数
    public int textLen = 201;//CSV内にある単語の数
    public int rnd = 0;//乱数用
    public int flg = 0;//文字比較管理用
    public int t_flg = 0;//乱数生成管理用
    public int firstflg = 0;//始めの乱数管理用

    public string input;
    public int inputLen = 0;

    // InputFieldのText参照用
    public TMP_InputField Field;

    void Update()
    {
        int wordLen = textLen - num;

        if(firstflg == 0)
        {
            //ランダム生成
            rnd = Random.Range(1, textLen);
            //表示
            kanjiText.text = CSVReader.csvDatas[rnd][1];
            huriganaText.text = CSVReader.csvDatas[rnd][2];

            firstflg = 1;//無効にする
            Field.Select();//フォーカスする
        }

        if (t_flg == 1)
        {
            //ランダム生成
            rnd = Random.Range(1, wordLen);
            //表示
            kanjiText.text = CSVReader.csvDatas[rnd][1];
            huriganaText.text = CSVReader.csvDatas[rnd][2];

            t_flg = 0;//ランダム生成を無効にする
        }
        flg = KanaComp(rnd);
        //文字比較があっていれば
        if (flg == 1)
        {
            //rndの言葉が上書きされる(消される)
            for (int i = 1; i < wordLen - 1; i++)
            {
                if (i >= rnd)
                {
                    CSVReader.csvDatas[i][1] = CSVReader.csvDatas[i + 1][1];
                    CSVReader.csvDatas[i][2] = CSVReader.csvDatas[i + 1][2];
                }
            }
            num++;
            t_flg = 1;//ランダム生成を有効にする
            Field.GetComponent<TMP_InputField>().text = "";//空白にする
        }

        if (wordLen == 0) UnityEditor.EditorApplication.isPaused = true;//一時停止
    }

    public void OnValueChanged()//リアルタイムで文字の取得
    {
        input = Field.GetComponent<TMP_InputField>().text;//入力された文字を格納
        inputLen = input.Length;//比較する入力された文字の長さの取得
    }

    int KanaComp(int rnd)
    {
        int kanaflg = 0;
        string kana = CSVReader.csvDatas[rnd][2];//フリガナの取得
        int kanaLen = kana.Length;//比較したいフリガナの長さを取得
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
