using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class syougou : MonoBehaviour
{
    public string Dmoji;
    public string Cmoji;
    public string Bmoji;
    public string Amoji;
    public string Smoji;

    public TextMeshProUGUI syougoutext;

    void Start()
    {
        int point = 5000;

        if (point == 5000)
        {

            string D = D_syougou();
            Debug.Log(D_syougou());
            syougoutext.text = D;

        }

        if (point == 10000)
        {
            string C = C_syougou();
            Debug.Log(C);
        }

        if (point == 15000)
        {
            string B = B_syougou();
            Debug.Log(B);
        }

        if (point == 20000)
        {
            string A = A_syougou();
            Debug.Log(A);
        }

        if (point == 25000)
        {
            string S = S_syougou();
            Debug.Log(S);
        }
    }

    string D_syougou()
    {
        int D = 0;
        D = UnityEngine.Random.Range(1, 9);
        //D�̏̍��P�`�W
        
        switch (D)
        {
            case 1:
                Dmoji = "�ڌ���";
                break;
            case 2:
                Dmoji = "�V��";
                break;
            case 3:
                Dmoji = "����";
                break;
            case 4:
                Dmoji = "�ؐl";
                break;
            case 5:
                Dmoji = "�T�K��";
                break;
            case 6:
                Dmoji = "���";
                break;
            case 7:
                Dmoji = "�V��";
                break;
            case 8:
                Dmoji = "��";
                break;
        }

        return Dmoji;
    }

    string C_syougou()
    {
        int C;
        C = UnityEngine.Random.Range(1, 11);
        //C�̏̍��P�`�P�O
        switch (C)
        {
            case 1:
                Cmoji = "�����";
                break;
            case 2:
                Cmoji = "�w��";
                break;
            case 3:
                Cmoji = "�A�Ҏ�";
                break;
            case 4:
                Cmoji = "�b";
                break;
            case 5:
                Cmoji = "���F";
                break;
            case 6:
                Cmoji = "����";
                break;
            case 7:
                Cmoji = "���͎�";
                break;
            case 8:
                Cmoji = "�T����";
                break;
            case 9:
                Cmoji = "���e";
                break;
            case 10:
                Cmoji = "���";
                break;
        }

        return Cmoji;
    }

    string B_syougou()
    {
        int B;
        B = UnityEngine.Random.Range(1, 16);
        switch (B)
        {
            case 1:
                Bmoji = "���t";
                break;
            case 2:
                Bmoji = "����";
                break;
            case 3:
                Bmoji = "������";
                break;
            case 4:
                Bmoji = "��]";
                break;
            case 5:
                Bmoji = "��]";
                break;
            case 6:
                Bmoji = "�B���p�t";
                break;
            case 7:
                Bmoji = "����";
                break;
            case 8:
                Bmoji = "����";
                break;
            case 9:
                Bmoji = "�I��";
                break;
            case 10:
                Bmoji = "��m";
                break;
            case 11:
                Bmoji = "���l";
                break;
            case 12:
                Bmoji = "����";
                break;
            case 13:
                Bmoji = "�h�q";
                break;
            case 14:
                Bmoji = "�ꓙ��";
                break;
            case 15:
                Bmoji = "���g";
                break;
        }

        return Bmoji;
    }

    string A_syougou()
    {
        int A;
        A = UnityEngine.Random.Range(1, 14);
        // A�̏̍��P�`�P�R
        switch (A)
        {
            case 1:
                Amoji = "�E��";
                break;
            case 2:
                Amoji = "���z��";
                break;
            case 3:
                Amoji = "����";
                break;
            case 4:
                Amoji = "����";
                break;
            case 5:
                Amoji = "�����";
                break;
            case 6:
                Amoji = "���R�m";
                break;
            case 7:
                Amoji = "�V�g";
                break;
            case 8:
                Amoji = "�e��";
                break;
            case 9:
                Amoji = "���p�t";
                break;
            case 10:
                Amoji = "�鉤";
                break;
            case 11:
                Amoji = "�s����";
                break;
            case 12:
                Amoji = "�����I�A�C�h��";
                break;
            case 13:
                Amoji = "�e��";
                break;
        }

        return Amoji;
    }
    string S_syougou()
    {
        int S;
        S = UnityEngine.Random.Range(1, 5);
        switch (S)
        {
            case 1:
                Smoji = "�Ō��@�_";
                break;
            case 2:
                Smoji = "�Ō����_";
                break;
            case 3:
                Smoji = "�Ō��א_";
                break;
            case 4:
                Smoji = "�Ō��_";
                break;
        }

        return Smoji;
    }

    
}