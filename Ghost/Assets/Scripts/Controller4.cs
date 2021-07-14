using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller4 : MonoBehaviour
{
    public GameObject turner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      private void OnTriggerEnter2D(Collider2D other) {
       PeterController controller = other.GetComponent<PeterController>();
    if (controller != null)
    {
       turner.SetActive(true);
       Time.timeScale=0f;
    }
      }

}
