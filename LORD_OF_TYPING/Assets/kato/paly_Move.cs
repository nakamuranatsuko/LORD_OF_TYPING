using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class paly_Move : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("New Scene", LoadSceneMode.Single);
    }  
}
