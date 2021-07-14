using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public AudioSource aud;
     void Update(){
       if (Input.GetKey(KeyCode.Escape))
            { SceneManager.LoadScene(0);
    }
 
            }
   
   public void GoToLevel(int level){
       aud.Play();
        SceneManager.LoadScene(level+1);
    }
    public void GoToHome(){
       aud.Play();
        SceneManager.LoadScene(0);
    }
}
