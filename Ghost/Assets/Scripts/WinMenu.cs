using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
public bool victory=false;
public GameObject Menu;
    
ProgressData pd;
int level=0;
    private void Start() {
         pd=SaveAndLoad.LoadData(); 
         if(pd!=null)
         {
level=pd.level;
         }
        if(victory&&level<SceneManager.GetActiveScene().buildIndex)
         {
         int adder=0;
         if(SceneManager.GetActiveScene().buildIndex==13)
         adder=1;
         pd.updatelevel(SceneManager.GetActiveScene().buildIndex+adder);
         SaveAndLoad.SaveData(pd);
         } 
    }
    public void Quit(){
        SceneManager.LoadScene(0);
    }
     public void NextLevel(){
         int adder=1;
         if(SceneManager.GetActiveScene().buildIndex==13)
         adder=2;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+adder);
    }
    public void Continue(){
        Menu.SetActive(false);
        Time.timeScale=1f;
    }
     public void Retry(){
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   
    }
}
