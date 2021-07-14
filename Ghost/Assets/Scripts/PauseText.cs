using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseText : MonoBehaviour
{
    
    TextMeshProUGUI textOb,scoreText;

    public GameObject score;
    void Start()
    {
        textOb=GetComponent<TextMeshProUGUI>();
        scoreText=score.GetComponent<TextMeshProUGUI>();
    
            textOb.text= "Time: "+ scoreText.text;
    }

   public void TimeUpdate()
    {
            textOb.text= "Time: "+ scoreText.text;
    }
}
