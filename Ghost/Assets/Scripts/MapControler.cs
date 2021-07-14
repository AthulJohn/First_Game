using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControler : MonoBehaviour
{
   bool TurnOnMap=false;
   
   public GameObject MapButton,Map;
   public bool isTutorial=false;
    

    private void OnTriggerEnter2D(Collider2D other) {
       PeterController controller = other.GetComponent<PeterController>();
    if (controller != null)
    {
 if(TurnOnMap)
{
    TurnOff();
}
else
{
    TurnOn();
}
    }
  }
  private void OnTriggerExit2D(Collider2D other) {
       PeterController controller = other.GetComponent<PeterController>();
    if (controller != null)
    {
 if(TurnOnMap)
{
    TurnOff();
}
else
{
    TurnOn();
}
    }
  }

    public void TurnOff(){
        MapButton.SetActive(false);
        TurnOnMap=false;
    }
    void TurnOn(){
        if(isTutorial)
       Time.timeScale=0f;
        MapButton.SetActive(true);
        TurnOnMap=true;
    }

   public void TurnOffMap(){
       Map.SetActive(false);
       Time.timeScale=1f;
    
   }

}
