using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public GameObject BackgroundToggle,SwipeToggle;
    Toggle backtog,swipetog;
    bool value=true;
    ProgressData pd;

    private void Start() {
        backtog=BackgroundToggle.GetComponent<Toggle>();
        swipetog=SwipeToggle.GetComponent<Toggle>();
        pd=SaveAndLoad.LoadData();
        backtog.isOn=pd.backgroundSoundEnabled;
        swipetog.isOn=pd.swipeSoundEnabled;
        Debug.Log(pd.backgroundSoundEnabled);
        Debug.Log(pd.swipeSoundEnabled);
        
    }
        
    public void ChangeBackgroundSound()
    {
        value=BackgroundToggle.GetComponent<Toggle>().isOn;

        pd=SaveAndLoad.LoadData();
        pd.updateBGS(value);
        Debug.Log(pd.backgroundSoundEnabled);
        SaveAndLoad.SaveData(pd);
         
    }
    
    public void ChangeSwipeSound()
    {
        value=SwipeToggle.GetComponent<Toggle>().isOn;

        pd=SaveAndLoad.LoadData();
        pd.updateSS(value);
        Debug.Log(pd.swipeSoundEnabled);
        SaveAndLoad.SaveData(pd);
    }
}
