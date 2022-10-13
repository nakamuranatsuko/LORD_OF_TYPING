using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rizaruto_title : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("title", LoadSceneMode.Single);
    }
}