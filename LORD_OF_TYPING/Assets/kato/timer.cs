using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    private float time = 60.0f;
    public Text timerText;
    public bool isTimeUp;

    void Start()
    {
        isTimeUp = false;
    }

    void Update()
    {
        if (0 < time)
        {
            time -= Time.deltaTime;
            timerText.text = time.ToString("F1");
        }
        else if (time < 0)
        {
            isTimeUp = true;
        }
    }
}