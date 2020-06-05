using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using Object = System.Object;
using Random = UnityEngine.Random;

public class DataManager : MonoBehaviour
{

    string url = "https://covidtracking.com/api/v1/states/current.json";
    StateData[] m_States;
    bool m_DataCaptured;

    public bool dataCaptured
    {
        get => m_DataCaptured;
    }

    void OnEnable()
    {
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log("Error occured with web request");
            }
            else
            {
                m_States = JsonConvert.DeserializeObject<StateData[]>(webRequest.downloadHandler.text);

                m_DataCaptured = true;
            }
        }        
    }

    public int? GetStatePositiveCases(DataUIDisplay.StateCode stateCode)
    {
        if (m_DataCaptured)
        {
            return m_States[GetStateIndex(stateCode)].positive;
        }
        else
        {
            return -1;
        }
    }
    
    public int GetStateIndex(DataUIDisplay.StateCode stateCode)
    {
        return (int)stateCode;
    }
}



public class StateData
{
    public string state;
    public int? positive;
    public int? positiveScore;
    public int? negativeScore;
    public int? negativeRegularScore;
    public int? commercialScore;
    public string grade;
    public int? score;
    public string notes;
    public string dataQualityGrade;
    public int? negative;
    public Object pending;
    public int? hospitalizedCurrently;
    public Object hospitalizedCumulative;
    public Object inIcuCurrently;
    public Object inIcuCumulative;
    public Object onVentilatorCurrently;
    public Object onVentilatorCumulative;
    public int? recovered;
    public string lastUpdateEt;
    public string checkTimeEt;
    public int? death;
    public Object hospitalized;
    public int? total;
    public int? totalTestResults;
    public int? posNeg;
    public string fips;
    public DateTime dateModified;
    public DateTime dateChecked;
    public string hash;
}
