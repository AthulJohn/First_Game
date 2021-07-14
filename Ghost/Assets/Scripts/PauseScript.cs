using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class PauseScript : MonoBehaviour
{
    public GameObject Menu,GameOver,pause;
    public GameObject[] Map;
    public GameObject score;
    TextMeshProUGUI scoreText;
public AudioSource sound;

    // Update is called once per frame
    void Start(){

   
        scoreText=score.GetComponent<TextMeshProUGUI>();
    
    }

    void FixedUpdate(){
        if(scoreText.text==" 00:00")
         OpenOver();
    }

    public void OpenMap(int mapNumber)
    {
        if(Map[mapNumber].activeSelf)
{
    Time.timeScale=1f;
    Map[mapNumber].SetActive(false);}
else
{
    Time.timeScale=0f;
    Map[mapNumber].SetActive(true);}
    }

    void OpenOver()
    {
      
sound.Play();
        pause.SetActive(false);
    Time.timeScale=0f;
    GameOver.SetActive(true);
    }
    
    public void OpenMenu()
    {
        if(Menu.activeSelf)
{
    Time.timeScale=1f;
    Menu.SetActive(false);}
else
{
    Time.timeScale=0f;
    Menu.SetActive(true);}
    }
}
