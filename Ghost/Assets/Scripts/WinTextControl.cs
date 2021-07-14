using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinTextControl : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    TextMeshProUGUI textOb,scoreText;

    public GameObject score;
    void Start()
    {
        textOb=GetComponent<TextMeshProUGUI>();
        scoreText=score.GetComponent<TextMeshProUGUI>();
    
            textOb.text= "Time: "+ scoreText.text;
    }

   void FixedUpdate()
    {
            textOb.text= "Time: "+ scoreText.text;
    }
}
