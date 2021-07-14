using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinDestroyer : MonoBehaviour
{
    public GameObject adder, remover;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        adder.SetActive(false);
        remover.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other) {
        adder.SetActive(true);
        remover.SetActive(false);
    }

    public void destroyer(){
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
