using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinControl : MonoBehaviour
{
    public GameObject pin,ghost;
    TextMeshProUGUI textOb;
    SpriteRenderer sp;
    int pinsNo=0;
    Color[] pinColors={Color.red,Color.blue,Color.cyan,Color.green, Color.magenta,Color.yellow};
    // Start is called before the first frame update
    void Start()
    {
        textOb=GetComponent<TextMeshProUGUI>();
    }

    public void spawn()
    {
        pinsNo=int.Parse(textOb.text);
        
        if(pinsNo>0)
        {
        GameObject p = Instantiate(pin) as GameObject;
        sp = p.GetComponent<SpriteRenderer>();
        sp.color = pinColors[pinsNo%6];
        p.transform.position= new Vector2(ghost.transform.position.x,ghost.transform.position.y);
        p.transform.rotation=ghost.transform.rotation;
        pinsNo--;
        textOb.text=pinsNo.ToString();
        }
    }

    public void remove()
    {
        pinsNo=int.Parse(textOb.text);
        pinsNo++;
        textOb.text=pinsNo.ToString();

    }
}
