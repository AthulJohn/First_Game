using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TextControl : MonoBehaviour
{
    
    TextMeshProUGUI textOb;
     public float TotalTime=61f;
    float finalTime=0f,timeLeft=0f;
    void Start()
    {
        textOb=GetComponent<TextMeshProUGUI>();
        finalTime=Time.time+TotalTime;
        
    }

   void FixedUpdate()
    {
        timeLeft=finalTime-Time.time;
        if(timeLeft<10)
        textOb.color=Color.red;
        textOb.text=" " +(Math.Floor(timeLeft/60)).ToString("00")+":"+ (timeLeft%60).ToString("00");
        
    }

    public void Reset(){
        finalTime=Time.time+TotalTime;
        
        Time.timeScale=1f;
    }
}
