using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
public bool victory=false;
public GameObject Menu,character;
    public GameObject loadingScreen;
    public Slider slider;
    PeterController script;
    
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
         if(SceneManager.GetActiveScene().buildIndex==14||SceneManager.GetActiveScene().buildIndex==27)
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
         if(SceneManager.GetActiveScene().buildIndex==14||SceneManager.GetActiveScene().buildIndex==27)
         adder=2;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+adder);
    }
    public void Continue(){
        Menu.SetActive(false);
        // OnClose();
        Time.timeScale=1f;
    }
     public void ReRandom(){
         
        loadingScreen.SetActive(true);
             StartCoroutine(LoadasAsync(SceneManager.GetActiveScene().buildIndex));
   
    }
    public void Retry(){
         
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   
    }


     public void PlayAgain(){
        if(character!=null)
           {script = character.GetComponent<PeterController>();
            character.transform.position=new Vector3(1.11f,2.1f,0f);
             script.Backward();
             Menu.SetActive(false);
             }
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
}
