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
        //DÇÃèÃçÜÇPÅ`ÇW
        
        switch (D)
        {
            case 1:
                Dmoji = "ñ⁄åÇé“";
                break;
            case 2:
                Dmoji = "êVêØ";
                break;
            case 3:
                Dmoji = "ïöï∫";
                break;
            case 4:
                Dmoji = "èÿêl";
                break;
            case 5:
                Dmoji = "íTñKé“";
                break;
            case 6:
                Dmoji = "é·é“";
                break;
            case 7:
                Dmoji = "êVïƒ";
                break;
            case 8:
                Dmoji = "óÎ";
                break;
        }

        return Dmoji;
    }

    string C_syougou()
    {
        int C;
        C = UnityEngine.Random.Range(1, 11);
        //CÇÃèÃçÜÇPÅ`ÇPÇO
        switch (C)
        {
            case 1:
                Cmoji = "íßêÌé“";
                break;
            case 2:
                Cmoji = "äwé“";
                break;
            case 3:
                Cmoji = "ãAä“é“";
                break;
            case 4:
                Cmoji = "èb";
                break;
            case 5:
                Cmoji = "âπêF";
                break;
            case 6:
                Cmoji = "íûéô";
                break;
            case 7:
                Cmoji = "é¿óÕé“";
                break;
            case 8:
                Cmoji = "íTãÜé“";
                break;
            case 9:
                Cmoji = "å∂âe";
                break;
            case 10:
                Cmoji = "àÓç»";
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
                Bmoji = "ì±ét";
                break;
            case 2:
                Bmoji = "éÁåÏé“";
                break;
            case 3:
                Bmoji = "ãÅìπé“";
                break;
            case 4:
                Bmoji = "äÛñ]";
                break;
            case 5:
                Bmoji = "ê‚ñ]";
                break;
            case 6:
                Bmoji = "òBã‡èpét";
                break;
            case 7:
                Bmoji = "ê∏óÏ";
                break;
            case 8:
                Bmoji = "à´ñÇ";
                break;
            case 9:
                Bmoji = "çIé“";
                break;
            case 10:
                Bmoji = "êÌém";
                break;
            case 11:
                Bmoji = "í¥êl";
                break;
            case 12:
                Bmoji = "ã≠é“";
                break;
            case 13:
                Bmoji = "éhãq";
                break;
            case 14:
                Bmoji = "àÍìôêØ";
                break;
            case 15:
                Bmoji = "âªêg";
                break;
        }

        return Bmoji;
    }

    string A_syougou()
    {
        int A;
        A = UnityEngine.Random.Range(1, 14);
        // AÇÃèÃçÜÇPÅ`ÇPÇR
        switch (A)
        {
            case 1:
                Amoji = "óEé“";
                break;
            case 2:
                Amoji = "í¥âzé“";
                break;
            case 3:
                Amoji = "å´é“";
                break;
            case 4:
                Amoji = "åïêπ";
                break;
            case 5:
                Amoji = "í≤í‚é“";
                break;
            case 6:
                Amoji = "êπãRém";
                break;
            case 7:
                Amoji = "ë¬ìVég";
                break;
            case 8:
                Amoji = "îeâ§";
                break;
            case 9:
                Amoji = "ñÇèpét";
                break;
            case 10:
                Amoji = "íÈâ§";
                break;
            case 11:
                Amoji = "ïséÄíπ";
                break;
            case 12:
                Amoji = "çëñØìIÉAÉCÉhÉã";
                break;
            case 13:
                Amoji = "îeé“";
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
                Smoji = "ë≈åÆã@ê_";
                break;
            case 2:
                Smoji = "ë≈åÆó¥ê_";
                break;
            case 3:
                Smoji = "ë≈åÆé◊ê_";
                break;
            case 4:
                Smoji = "ë≈åÆê_";
                break;
        }

        return Smoji;
    }

    
}