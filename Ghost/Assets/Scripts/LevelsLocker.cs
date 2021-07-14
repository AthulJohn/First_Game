using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsLocker : MonoBehaviour
{
    public int level;

    ProgressData pd;
    Button button;
    Image img;
    // Start is called before the first frame update
    void Start()
    {
         pd=SaveAndLoad.LoadData(); 
         if(pd!=null)
         {
         if(level>pd.level)
         {
             button= gameObject.GetComponent<Button>();
             img = gameObject.GetComponent<Image>();
                Color cb = img.color;
        cb.a = 0.4f;
             img.color=cb;
             button.enabled=false;
         }}
    }

}
