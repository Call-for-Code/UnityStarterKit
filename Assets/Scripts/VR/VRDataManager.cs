using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRDataManager : MonoBehaviour
{
    [SerializeField]
    Dropdown m_State1Dropdown;

    [SerializeField]
    Dropdown m_State2Dropdown;

    [SerializeField]
    Dropdown m_State3Dropdown;

    [SerializeField]
    Dropdown m_State4Dropdown;

    [SerializeField]
    Dropdown m_State5Dropdown;

    [SerializeField]
    DataBarDisplay m_DataBarDisplay;

    [SerializeField]
    DataManager m_DataManager;

    void OnEnable()
    {
        m_State1Dropdown.onValueChanged.AddListener(State1Changed);
        m_State2Dropdown.onValueChanged.AddListener(State2Changed);
        m_State3Dropdown.onValueChanged.AddListener(State3Changed);
        m_State4Dropdown.onValueChanged.AddListener(State4Changed);
        m_State5Dropdown.onValueChanged.AddListener(State5Changed);
    }

    void OnDisable()
    {
        m_State1Dropdown.onValueChanged.RemoveListener(State1Changed);
        m_State2Dropdown.onValueChanged.RemoveListener(State2Changed);
        m_State3Dropdown.onValueChanged.RemoveListener(State3Changed);
        m_State4Dropdown.onValueChanged.RemoveListener(State4Changed);
        m_State5Dropdown.onValueChanged.RemoveListener(State5Changed);
    }

    void Awake()
    {
        m_State1Dropdown.value = m_DataManager.GetStateIndex(m_DataBarDisplay.stateCode1);
        m_State2Dropdown.value = m_DataManager.GetStateIndex(m_DataBarDisplay.stateCode2);
        m_State3Dropdown.value = m_DataManager.GetStateIndex(m_DataBarDisplay.stateCode3);
        m_State4Dropdown.value = m_DataManager.GetStateIndex(m_DataBarDisplay.stateCode4);
        m_State5Dropdown.value = m_DataManager.GetStateIndex(m_DataBarDisplay.stateCode5);
    }

    void State1Changed(Int32 val)
    {
        m_DataBarDisplay.stateCode1 = (DataUIDisplay.StateCode)val;
    }

    void State2Changed(Int32 val)
    {
        m_DataBarDisplay.stateCode2 = (DataUIDisplay.StateCode)val;
    }

    void State3Changed(Int32 val)
    {
        m_DataBarDisplay.stateCode3 = (DataUIDisplay.StateCode)val;
    }

    void State4Changed(Int32 val)
    {
        m_DataBarDisplay.stateCode4 = (DataUIDisplay.StateCode)val;
    }

    void State5Changed(Int32 val)
    {
        m_DataBarDisplay.stateCode5 = (DataUIDisplay.StateCode)val;
    }

}
