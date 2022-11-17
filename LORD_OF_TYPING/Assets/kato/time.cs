using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour
{
    public GameObject timeUp;

    void Start()
    {
        timeUp = GameObject.Find("GameObject");
    }

    void Update()
    {
        if (timeUp.GetComponent<timer>().isTimeUp == false)
        {
            transform.Rotate(new Vector3(0, 0, -0.0154f));
        }
    }
}