﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GetTime : MonoBehaviour
{

    int hour;
    int minute;
    int second;
    int millisecond;

    // 已经花费的时间 
    float timeSpend = 0.0f;

    // 显示时间区域的文本 
    public Text text_timeSpend;
    /*public string printtime()
    {
        
        return text_timeSpend.text;
    }*/
    // Use this for initialization 
    void Start()
    {
        text_timeSpend = GetComponent<Text>();
    }

    // Update is called once per frame 
    void Update()
    {
        timeSpend += Time.deltaTime;
        //GlobalSetting.timeSpent = timeSpend;

        hour = (int)timeSpend / 3600;
        minute = ((int)timeSpend - hour * 3600) / 60;
        second = (int)timeSpend - hour * 3600 - minute * 60;
        millisecond = (int)((timeSpend - (int)timeSpend) * 1000);

        text_timeSpend.text = string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}", hour, minute, second, millisecond);
    }
}