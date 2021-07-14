using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class PeterController : MonoBehaviour 
{
    private static PeterController _Instance;

    public float moveSpeed=10f,rotationRatio=5f;
    public AudioSource swipe,background;
    public bool isTutorial=false;
    int restrictor=1;
    Rigidbody2D rigidBody;
    bool moving=false;
    public int hordir=-1,verdir=0;
    Vector3 vel;
    float angle=0f,dir=0f,targetAngle=0f;
    
    private float SwipeEndTime,SwipeStartTime,SwipeTime,SwipeLength;
    private Vector2 SwipeEndpos,SwipeStartpos;
    Animator animator;
    ProgressData pd;

    public static PeterController Instance { get { return _Instance; } }

    void Awake()
{
    if (_Instance== null) 
    _Instance= this;
}

    void Start()
    {
      Time.timeScale=1f;
        rigidBody=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        pd=SaveAndLoad.LoadData();
        if(pd.backgroundSoundEnabled)
        {
          background.Play();
        }
        if(!pd.swipeSoundEnabled)
        {
          swipe.volume=0;
        }
        //  animator.SetFloat("IsMoving", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
          
          Forward();
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
          RotateRight();
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
          RotateLeft();
        }
        else if(Input.GetKeyDown(KeyCode.S))
        { Backward();
        }
         if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene(1);
 
            }
        SwipeTest();
    }

    private void FixedUpdate() {
       if(targetAngle<angle)
        {
            transform.Rotate(new Vector3(0,0,rotationRatio*dir));
            targetAngle+=rotationRatio;
        }
        else
        {
            angle=0f;
            targetAngle=0f;
             if(moving)
        transform.position=transform.position + new Vector3(hordir*moveSpeed* Time.deltaTime,verdir*moveSpeed* Time.deltaTime,0);
        
        }
    }


    void Forward(){
      
          if(!isTutorial||2%restrictor==0)
        {animator.SetFloat("IsMoving", 1);
        moving=true;}
    }
         
     void RotateRight(){
          if(!isTutorial||3%restrictor==0)
      { swipe.Play();
       if(angle==0)
       {
         int v= verdir;
          verdir=-hordir;
          hordir=v;
          angle=90f;
       dir=-1;}}
    }
    void RotateLeft(){
          if(!isTutorial||7%restrictor==0)
      { swipe.Play();
       if(angle==0)
       {
         angle=90f;
       dir=1;
         int h= hordir;
          hordir=-verdir;
          verdir=h;
       }}
    }
     void Backward(){
          if(!isTutorial||5%restrictor==0)
        {moving=false;
         animator.SetFloat("IsMoving", 0);}
    }

    public void ChangeRestrictor(int res){restrictor=res;}

    void SwipeTest(){
      if(Input.touchCount>0)
      {
        Touch touch=Input.GetTouch(0);
        if(touch.phase==TouchPhase.Began)
        {
          SwipeStartTime=Time.time;
          SwipeStartpos=touch.position;

        }
        else if(touch.phase==TouchPhase.Ended)
        {
          SwipeEndTime=Time.time;
          SwipeEndpos=touch.position;
          SwipeTime=SwipeEndTime-SwipeStartTime;
          SwipeLength=(SwipeEndpos-SwipeStartpos).magnitude;
        //   if(SwipeTime>MinSwipeTime&&SwipeTime<MaxSwipeTime&&SwipeLength>MinSwipeLength&&SwipeLength<MaxSwipeLength)
        // {
SwipeControl();
        // }
        }
        
      }
    }

    public void SwipeControl()
{
Vector2 dragVector =SwipeEndpos - SwipeStartpos;
float positiveX = Mathf.Abs(dragVector.x);
  float positiveY = Mathf.Abs(dragVector.y);
  if (positiveX > positiveY)
  {
    if (dragVector.x > 0)  RotateRight() ;
    else RotateLeft();
  }
  else
  {
    if(dragVector.y > 0) Forward();
    else Backward();
  }
}
}
