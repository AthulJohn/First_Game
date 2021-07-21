using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class TileMapMaker : MonoBehaviour
{
    public Tile grass,bush;
    public Tilemap tilemap;
    public GameObject target;
    public int size=11;
    int mid=5;
    int ox=0,oy=0;
    int [,] arr ;
    void Start()
    {
        arr=new int[size,size];
        mid=(size-1)/2;
        Generator();
        for(int x=(-mid)*3;x<=((size+1)/2)*3;x++)
           { Vector3Int p = new Vector3Int(x,(-mid)*3,0);
            tilemap.SetTile(p, bush);
            p = new Vector3Int((-mid)*3-1,x,0);
            tilemap.SetTile(p, bush);
            p = new Vector3Int(((size+1)/2)*3-1,x,0);
            tilemap.SetTile(p, bush);
            p = new Vector3Int(x,((size+1)/2)*3,0);
            tilemap.SetTile(p, bush);
            }

        for (int x = 0; x<size; x++)
{
    for (int y = 0; y<size; y++)
    {
        // Vector3Int p = new Vector3Int(x,y,0);
        createPart(arr[x,y],(-mid+x)*3,(-mid+y)*3);
    }
}
    
        ox=(-mid+ox)*3+1;
        oy=(-mid+oy)*3+2;
        target.transform.position=new Vector3Int(ox,oy,0);
    }

    void createPart(int no,int x,int y)
    {
        if(no==1||no==3)
        {
            for(int i=0;i<3;i++)
           { Vector3Int p = new Vector3Int(x+i,y,0);
            tilemap.SetTile(p, bush);}
        }
        if(no==2||no==3)
        {
            for(int i=0;i<3;i++)
           { Vector3Int p = new Vector3Int(x+2,y+i,0);
            tilemap.SetTile(p, bush);}
        }
    }

    void Generator(){
  oy=(size-1)/2;
  ox=(size-1)/2;
  int dir=0,predir=0;
  for(int i=0;i<size;i++)
  {for(int j=0;j<size;j++)
  {
    
      arr[i,j]=0;
  }}
  for(int i=0;i<5*size;i++)
  {
    dir=(dir+2)%4;
    predir=dir;
      int adder=Random.Range(1,4);
      dir=(dir+adder)%4;
      if(dir==1&&predir!=2)
      {arr[ox,oy]=1;
      }
      else if (dir==1)
      {arr[ox,oy]=4;

      }
      else if(dir==2&&predir!=1)
      {
          arr[ox,oy]=2;
      } 
      else if (dir==2)
      {arr[ox,oy]=4;

      }
      else 
      {

      int randval=Random.Range(0,11);
      if(randval==0)
      {if(predir!=1&&predir!=2)arr[ox,oy]=3;
      else arr[ox,oy]=4;}
      else if(randval<6)
      {if(predir!=2)arr[ox,oy]=1;
      else arr[ox,oy]=4;}
      else
      {if(predir!=1)arr[ox,oy]=2;
      else arr[ox,oy]=4;}
      }
      
      if(dir==1&&ox!=size-1)
      {
          if(arr[ox+1,oy]==0)
      ox++;
      else
      dir=(predir+2)%4;}
      else if(dir==2&&oy!=0)
      {
          if(arr[ox,oy-1]==0)
      oy--;
      else
      dir=(predir+2)%4;
      }
      else if(dir==3&&ox!=0)
      {
          if(arr[ox-1,oy]==0)ox--;
      else
      dir=(predir+2)%4;}
      else if(dir==0&&oy!=size-1)
     {
          if(arr[ox,oy+1]==0) oy++;
      else
      dir=(predir+2)%4;}
      
      else
      dir=(predir+2)%4;

          
  }
  arr[ox,oy]=4;
  for(int i=0;i<size;i++)
  {for(int j=0;j<size;j++)
  {
      if(arr[i,j]==0)
      {
     int randval=Random.Range(0,12);
          if(randval==0)
      arr[i,j]=3;
      else if(randval<6)
      arr[i,j]=1;
      else if(randval==11)
      arr[i,j]=4;
      else
      arr[i,j]=2;}
  }}
  
    }
   
}
