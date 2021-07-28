using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    ProgressData pd;
    public GameObject loadingScreen;
    public Slider slider;


   void Update(){
       if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
 
            }
   }
    public void Quit(){
        Application.Quit();
    }

     public void Play( AudioSource aud){
         
       aud.Play();
         pd=SaveAndLoad.LoadData(); 
         if(pd.level<=27)
        StartCoroutine(LoadasAsync(pd.level+2));
    }

    public void RandomPlay( AudioSource aud){
         
       aud.Play();
        StartCoroutine(LoadasAsync(2));
    }


     IEnumerator LoadasAsync(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        loadingScreen.SetActive(true);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/0.9f);
            slider.value=progress;
            yield return null;
        }
           
    }
     public void Settings(){
            //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   
    }
}
