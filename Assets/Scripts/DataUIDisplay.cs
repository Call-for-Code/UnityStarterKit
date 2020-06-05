using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataUIDisplay : MonoBehaviour
{
    [SerializeField]
    DataManager m_DataManager;

    [SerializeField]
    TMP_Text m_UIText;

    const string k_DefaultText = "Positive cases in "; 
    
    public enum StateCode
    {
        AK,
        AL,
        AR,
        AS,
        AZ,
        CA,
        CO,
        CT,
        DC,
        DE,
        FL,
        GA,
        GU,
        HI,
        IA,
        ID,
        IL,
        IN,
        KS,
        KY,
        LA,
        MA,
        MD,
        ME,
        MI,
        MN,
        MO,
        MP,
        MS,
        MT,
        NC,
        ND,
        NE,
        NH,
        NJ,
        NM,
        NV,
        NY,
        OH,
        OK,
        OR,
        PA,
        PR,
        RI,
        SC,
        SD,
        TN,
        TX,
        UT,
        VA,
        VI,
        VT,
        WA,
        WI,
        WV,
        WY
    }

    public StateCode stateCode;

    void Update()
    {
        if (m_DataManager.dataCaptured)
        {
            m_UIText.text = k_DefaultText + stateCode.ToString()+ ": " + m_DataManager.GetStatePositiveCases(stateCode).ToString();
        }
    }
    
}
