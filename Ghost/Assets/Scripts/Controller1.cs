using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller1 : MonoBehaviour
{
    // public PeterController MyPeterController;
    public GameObject upObject;
    public bool playTime=false,tutorialended=false;
    bool touched=false;
    void Start(){
       PeterController.Instance.ChangeRestrictor(11);
            Time.timeScale=0f;
    }
    void Update()
    {
        if(Input.touchCount>0)
        {   Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
                {
                    touched=true;
                }
        if (touch.phase == TouchPhase.Ended&&touched)
                {
            if(upObject!=null)
            upObject.SetActive(true);
            if(playTime)
            Time.timeScale=1f;
            if(tutorialended)
            PeterController.Instance.ChangeRestrictor(1);
            Destroy(gameObject);
                }
        }
         if (Input.GetMouseButtonDown(0))
         {
            if(upObject!=null)
            upObject.SetActive(true);
            if(playTime)
            Time.timeScale=1f;
            if(tutorialended)
            PeterController.Instance.ChangeRestrictor(1);
             Destroy(gameObject);}
    }
}
