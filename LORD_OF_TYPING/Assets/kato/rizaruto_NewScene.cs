using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rizaruto_NewScene : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("New Scene", LoadSceneMode.Single);
    }
}