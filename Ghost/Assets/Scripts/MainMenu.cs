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
     public void Levels( AudioSource aud){
       aud.Play();
        SceneManager.LoadScene(1);
    }

     public void Play( AudioSource aud){
         
       aud.Play();
         pd=SaveAndLoad.LoadData(); 
        StartCoroutine(LoadasAsync(pd.level+1));
    }

     IEnumerator LoadasAsync(int index)
    {
            Debug.Log(index);
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
            Debug.Log(operation.progress);
        loadingScreen.SetActive(true);
        while(!operation.isDone)
        {
            Debug.Log(operation.progress);
            float progress = Mathf.Clamp01(operation.progress/0.9f);
            slider.value=progress;
            yield return null;
        }
           
    }
     public void Settings(){
            //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   
    }
}
