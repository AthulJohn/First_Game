
using UnityEngine;


public class ControllerLeft : MonoBehaviour
{
      private float SwipeEndTime,SwipeStartTime,SwipeTime,SwipeLength;
    private Vector2 SwipeEndpos,SwipeStartpos;
    
    public PeterController MyPeterController;
    void Start(){
       MyPeterController.ChangeRestrictor(7);
    }
    void Update()
    {
        SwipeTest();
        if(Input.GetKeyDown(KeyCode.A))
        {
            Time.timeScale=1f;
            Destroy(gameObject);
        }
    }

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
    
    if(dragVector.x < 0)
    {
            Time.timeScale=1f;
        Destroy(gameObject);
    }
  }
}

}
