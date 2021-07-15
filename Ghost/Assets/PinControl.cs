using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PinControl : MonoBehaviour
{
    public GameObject pin,ghost,adder,remover;
    TextMeshProUGUI textOb;
    SpriteRenderer sp;
    Image img;
    int pinsNo=0,pid=0;
    Color[] pinColors={Color.red,Color.blue,Color.cyan,Color.green, Color.magenta,Color.yellow};
    
    string pintempname;
    GameObject currentpin;



    private static PinControl _Instance;

    public static PinControl Instance { get { return _Instance; } }
    void Awake()
    {
    if (_Instance== null)
    _Instance= this;
    }
    // Start is called before the first frame update
    void Start()
    {
        textOb=GetComponent<TextMeshProUGUI>();
        img=adder.GetComponent<Image>();
    }

    public void ToAddButton()
    {
        adder.SetActive(true);
        remover.SetActive(false);

    }
    public void ToRemoveButton(string tag)
    {
        pintempname=tag;
        adder.SetActive(false);
        remover.SetActive(true);

    }
    public void spawn()
    {
        pinsNo=int.Parse(textOb.text);
        if(pinsNo>0)
        {
        GameObject p = Instantiate(pin) as GameObject;
        sp = p.GetComponent<SpriteRenderer>();
        sp.color = pinColors[pid%6];
        pid++;
        p.transform.position= new Vector2(ghost.transform.position.x,ghost.transform.position.y);
        p.transform.rotation=ghost.transform.rotation;
        pinsNo--;
        p.name=pid.ToString();
        pintempname=p.name;
        textOb.text=pinsNo.ToString();
        if(pinsNo==0)
        {
            Color col=img.color;
            col.a=0.2f;
            img.color=col;}
            
        }
    }

    public void remove()
    {
        pinsNo=int.Parse(textOb.text);
        pinsNo++;
        textOb.text=pinsNo.ToString();
        if(pintempname!=null)
        {
        currentpin=GameObject.Find(pintempname);
        Destroy(currentpin);
        }
        if(pinsNo==1)
        {
                Color col=img.color;
            col.a=0.6f;
            img.color=col;
            }
        ToAddButton();
    }
}
