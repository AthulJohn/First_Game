using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public AudioSource aud;
     void Update(){
       if (Input.GetKey(KeyCode.Escape))
            { SceneManager.LoadScene(0);
    }
 
            }
   
   public void GoToLevel(int level){
       aud.Play();
        StartCoroutine(LoadasAsync(level+2));
    }
    public void GoToHome(){
       aud.Play();
        SceneManager.LoadScene(0);
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
}
