using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    private int height,width;

    private int[,] gridArray;

    GridScript(int h,int w){
        height=h;width=w;
        gridArray=new int[h,w];
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
