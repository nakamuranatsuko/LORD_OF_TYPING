using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class rerult : MonoBehaviour
{
    public TextMeshProUGUI scoreText;//�\�������I�u�W�F�N�g�p
    public int score;

    void Update()
    {
        score = inputField_Comp.score;
        scoreText.text = score.ToString();
    }
}
