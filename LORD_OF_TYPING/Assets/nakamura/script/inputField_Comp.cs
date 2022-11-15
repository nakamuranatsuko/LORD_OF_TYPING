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

    public static int score = 0;//スコア用
    public int scoreNum = 1000;//スコア増加分

    public static int flg = 0;//文字比較管理用
    public int t_flg = 0;//乱数生成管理用
    public int firstflg = 0;//始めの乱数管理用
    public int chanFlg = 0;

    public string input;//入力された文字
    public int inputLen = 0;//入力された文字の長さ

    // InputFieldのText参照用
    public TMP_InputField Field;

    public GameObject BG;//背景管理

    //NomalGame用
    public int num = 0;//使用した単語の数
    public int textLen = 201;//CSV内にある単語の数
    public int rnd = 0;//乱数用

    //ShortGame用
    public int num_s = 0;//使用した単語の数
    public int textLen_s = 51;//CSV内にある単語の数
    public int rnd_s = 0;//乱数用

    void Start()
    {
        score = 0;//初期化
    }

    void Update()
    {
        if (countDown.isTimeUp == false)//タイムアップじゃなければ
        {
            if (chanFlg == 0) NomalGame();
            else
            {
                if (shortCountDown.isTimeUp == false) ShortGame();
                else chanFlg = 0;//チェンジフラグを0にする
                
            }
        }
        else StartCoroutine("TimeUp");//コルーチンの実行
    }

    void NomalGame()
    {
        BG.SetActive(true);//表示

        int wordLen = textLen - num;

        if (firstflg == 0)
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

        flg = KanaComp(huriganaText.text);//文字比較

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
            score += scoreNum;//スコアを足す
            t_flg = 1;//ランダム生成を有効にする
            Field.GetComponent<TMP_InputField>().text = "";//空白にする

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
        BG.SetActive(false);//非表示

        if (shortCountDown.isTimeUp == false)
        {
            int wordLen_short = textLen_s - num_s;

            if (t_flg == 1)
            {
                //ランダム生成
                rnd_s = Random.Range(1, wordLen_short);
                //表示
                kanjiText.text = CSV_short.csvDatas[rnd_s][1];
                huriganaText.text = CSV_short.csvDatas[rnd_s][2];

                t_flg = 0;//ランダム生成を無効にする
            }

            flg = KanaComp(huriganaText.text);//文字比較

            //文字比較があっていれば
            if (flg == 1)
            {
                //rnd_sの言葉が上書きされる(消される)
                for (int i = 1; i < wordLen_short - 1; i++)
                {
                    if (i >= rnd_s)
                    {
                        CSV_short.csvDatas[i][1] = CSV_short.csvDatas[i + 1][1];
                        CSV_short.csvDatas[i][2] = CSV_short.csvDatas[i + 1][2];
                    }
                }
                num_s++;
                score += scoreNum;//スコアを足す
                t_flg = 1;//ランダム生成を有効にする
                Field.GetComponent<TMP_InputField>().text = "";//空白にする
            }
        }
        else chanFlg = 0;//チェンジフラグを0にする
            
    }

    public void OnValueChanged()//リアルタイムで文字の取得
    {
        input = Field.GetComponent<TMP_InputField>().text;//入力された文字を格納
        inputLen = input.Length;//比較する入力された文字の長さの取得
    }

    int KanaComp(string moji)
    {
        int kanaflg = 0;
        int kanaLen = moji.Length;//比較したいフリガナの長さを取得
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
        //3秒待つ
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("result", LoadSceneMode.Single);
    }
}
