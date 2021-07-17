using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinTutorialControl_1 : MonoBehaviour
{
    public GameObject defaultpin, specialpin,nextObject;
    bool touched=false;
    // Start is called before the first frame update
    void Start()
    {
        defaultpin.SetActive(false);
        specialpin.SetActive(true);
        
    }

    // Update is called once per frame
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
            Misc();
                }
        }
         if (Input.GetMouseButtonDown(0))
         {
            Misc();}
    }
       
    void Misc(){
         defaultpin.SetActive(true);
         if(nextObject!=null)
            nextObject.SetActive(true);
            Destroy(gameObject);

    }
 
    }