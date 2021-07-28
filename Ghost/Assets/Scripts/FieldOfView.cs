using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh=mesh;
    Vector3 origin=Vector3.zero;
        float fov=360f;
        int rayCount=10;
        float angle=0f;
        float angleIncrease = fov/rayCount;
        float viewDistance=1f;
        Vector3[] vertices = new Vector3[rayCount+2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount*3];

        vertices[0]=origin;
        int verIndex=1;
        int triIndex=0;
        CompositeCollider2D[] colliders = Tilemap.FindObjectsOfType<CompositeCollider2D>();
        for(int i=0;i<=rayCount;i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit=Physics2D.Raycast(origin,VecFromAngle(angle),viewDistance);
            
                //||raycastHit.collider.name!="ShadowCaster2D"
            if(raycastHit.collider== null)
            {
                 vertex = origin+ VecFromAngle(angle)*viewDistance;
            }
            else 
            {  Debug.Log(raycastHit.collider.gameObject);
              
                vertex=raycastHit.point;
                Debug.Log(raycastHit.collider.name);
                Debug.Log(vertex);
            }
            vertices[verIndex]=vertex;

            if(i>0){
            triangles[triIndex+0]=0;
            triangles[triIndex+1]=verIndex-1;
            triangles[triIndex+2]=verIndex;
            triIndex+=3;
            }
            verIndex++;
            angle-=angleIncrease;
        }

    triangles[0]=0;
    triangles[1]=1;
    triangles[2]=2;

        mesh.vertices=vertices;
        mesh.uv=uv;
        mesh.triangles=triangles;
    }
    
    Vector3 VecFromAngle(float angle)
    {
        float angleRad=angle*(Mathf.PI/180f);
        return new Vector3(Mathf.Cos(angleRad),Mathf.Sin(angleRad));
    }
    
}
