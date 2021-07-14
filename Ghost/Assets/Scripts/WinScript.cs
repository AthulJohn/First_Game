using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WinScript : MonoBehaviour
{
public GameObject dialogBox,pausemenu;
public AudioSource sound;
    void Start()
    {
        dialogBox.SetActive(false);}

  private void OnTriggerEnter2D(Collider2D other) {
       PeterController controller = other.GetComponent<PeterController>();
    if (controller != null)
    {
        pausemenu.SetActive(false);
sound.Play();
    Time.timeScale=0f;
dialogBox.SetActive(true);
    }
  }
}
