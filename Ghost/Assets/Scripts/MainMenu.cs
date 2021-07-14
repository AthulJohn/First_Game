using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    ProgressData pd;

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
         if(pd!=null)
         {
        SceneManager.LoadScene(1+pd.level);}
        else
        SceneManager.LoadScene(2);
    }
     public void Settings(){
            //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   
    }
}
