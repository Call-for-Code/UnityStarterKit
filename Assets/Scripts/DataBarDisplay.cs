using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataBarDisplay : MonoBehaviour
{
    [SerializeField]
    DataManager m_DataManager;
    
    [SerializeField]
    TMP_Text m_State1;

    [SerializeField]
    TMP_Text m_Value1;

    [SerializeField]
    Transform m_Bar1;

    [SerializeField]
    TMP_Text m_State2;

    [SerializeField]
    TMP_Text m_Value2;

    [SerializeField]
    Transform m_Bar2;

    [SerializeField]
    TMP_Text m_State3;

    [SerializeField]
    TMP_Text m_Value3;

    [SerializeField]
    Transform m_Bar3;

    [SerializeField]
    TMP_Text m_State4;

    [SerializeField]
    TMP_Text m_Value4;

    [SerializeField]
    Transform m_Bar4;

    [SerializeField]
    TMP_Text m_State5;

    [SerializeField]
    TMP_Text m_Value5;

    [SerializeField]
    Transform m_Bar5;

    [SerializeField]
    DataUIDisplay.StateCode m_StateCode1;

    public DataUIDisplay.StateCode stateCode1
    {
        get => m_StateCode1;
        set => m_StateCode1 = value;
    }

    [SerializeField]
    DataUIDisplay.StateCode m_StateCode2;

    public DataUIDisplay.StateCode stateCode2
    {
        get => m_StateCode2;
        set => m_StateCode2 = value;
    }

    [SerializeField]
    DataUIDisplay.StateCode m_StateCode3;

    public DataUIDisplay.StateCode stateCode3
    {
        get => m_StateCode3;
        set => m_StateCode3 = value;
    }

    [SerializeField]
    DataUIDisplay.StateCode m_StateCode4;

    public DataUIDisplay.StateCode stateCode4
    {
        get => m_StateCode4;
        set => m_StateCode4 = value;
    }

    [SerializeField]
    DataUIDisplay.StateCode m_StateCode5;

    public DataUIDisplay.StateCode stateCode5
    {
        get => m_StateCode5;
        set => m_StateCode5 = value;
    }

    int? m_PositiveValues1;
    int? m_PositiveValues2;
    int? m_PositiveValues3;
    int? m_PositiveValues4;
    int? m_PositiveValues5;
    int?[] m_CurrentValue;

    bool m_DataChanged;
    bool m_DataSet;
    const int k_ValueMod = 5;

    DataUIDisplay.StateCode m_SetStateCode1;
    DataUIDisplay.StateCode m_SetStateCode2;
    DataUIDisplay.StateCode m_SetStateCode3;
    DataUIDisplay.StateCode m_SetStateCode4;
    DataUIDisplay.StateCode m_SetStateCode5;

    void Start()
    {
        m_PositiveValues1 = m_DataManager.GetStatePositiveCases(m_StateCode1);
        m_PositiveValues2 = m_DataManager.GetStatePositiveCases(m_StateCode2);
        m_PositiveValues3 = m_DataManager.GetStatePositiveCases(m_StateCode3);
        m_PositiveValues4 = m_DataManager.GetStatePositiveCases(m_StateCode4);
        m_PositiveValues5 = m_DataManager.GetStatePositiveCases(m_StateCode5);

        m_SetStateCode1 = m_StateCode1;
        m_SetStateCode2 = m_StateCode2;
        m_SetStateCode3 = m_StateCode3;
        m_SetStateCode4 = m_StateCode4;
        m_SetStateCode5 = m_StateCode5;

        m_CurrentValue = new[] { m_PositiveValues1, m_PositiveValues2, m_PositiveValues3, m_PositiveValues4, m_PositiveValues5 };
    }

    void Update()
    {
        if (m_DataManager.dataCaptured && !m_DataSet)
        {
            m_PositiveValues1 = m_DataManager.GetStatePositiveCases(m_StateCode1);
            m_PositiveValues2 = m_DataManager.GetStatePositiveCases(m_StateCode2);
            m_PositiveValues3 = m_DataManager.GetStatePositiveCases(m_StateCode3);
            m_PositiveValues4 = m_DataManager.GetStatePositiveCases(m_StateCode4);
            m_PositiveValues5 = m_DataManager.GetStatePositiveCases(m_StateCode5);
            
            m_CurrentValue = new[] { m_PositiveValues1, m_PositiveValues2, m_PositiveValues3, m_PositiveValues4, m_PositiveValues5 };
            m_DataSet = true;
        }
        
        m_State1.text = m_StateCode1.ToString();
        m_State2.text = m_StateCode2.ToString();
        m_State3.text = m_StateCode3.ToString();
        m_State4.text = m_StateCode4.ToString();
        m_State5.text = m_StateCode5.ToString();

        m_Value1.text = m_CurrentValue[0].ToString();
        m_Value2.text = m_CurrentValue[1].ToString();
        m_Value3.text = m_CurrentValue[2].ToString();
        m_Value4.text = m_CurrentValue[3].ToString();
        m_Value5.text = m_CurrentValue[4].ToString();

        if (m_DataSet)
        {
            m_Bar1.transform.localScale = new Vector3(1, GetNormalizedValue(m_CurrentValue[0]), 1);
            m_Bar2.transform.localScale = new Vector3(1, GetNormalizedValue(m_CurrentValue[1]), 1);
            m_Bar3.transform.localScale = new Vector3(1, GetNormalizedValue(m_CurrentValue[2]), 1);
            m_Bar4.transform.localScale = new Vector3(1, GetNormalizedValue(m_CurrentValue[3]), 1);
            m_Bar5.transform.localScale = new Vector3(1, GetNormalizedValue(m_CurrentValue[4]), 1);
        }

        if (m_StateCode1 != m_SetStateCode1 ||
            m_StateCode2 != m_SetStateCode2 ||
            m_StateCode3 != m_SetStateCode3 ||
            m_StateCode4 != m_SetStateCode4 ||
            m_StateCode5 != m_SetStateCode5)
        {
            m_SetStateCode1 = m_StateCode1;
            m_SetStateCode2 = m_StateCode2;
            m_SetStateCode3 = m_StateCode3;
            m_SetStateCode4 = m_StateCode4;
            m_SetStateCode5 = m_StateCode5;
            m_DataSet = false;
        }
            
    }

    float GetNormalizedValue(int? value)
    {
        float retVal = ((float)value - (float)GetLowestValue()) / ((float)GetHighestValue() - (float)GetLowestValue());
        return (retVal + 0.25f)* k_ValueMod;
    }

    int? GetHighestValue()
    {
        int? highestValue = -1;

        for (int i = 0; i < m_CurrentValue.Length; i++)
        {
            if (m_CurrentValue[i] > highestValue)
            {
                highestValue = m_CurrentValue[i];
            }
        }

        return highestValue;
    }

    int? GetLowestValue()
    {
        int? lowestValue = Int32.MaxValue;
        
        for (int i = 0; i < m_CurrentValue.Length; i++)
        {
            if (m_CurrentValue[i] < lowestValue)
            {
                lowestValue = m_CurrentValue[i];
            }
        }

        return lowestValue;
    }
}
