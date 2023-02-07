using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEngine : MonoBehaviour
{
  [SerializeField]
   private Transform lookAt;//object camera follows
   [SerializeField]
   private float boundX = 0.15f;//how close the camera follows
   [SerializeField]
   private float boundY = 0.05f;

    private void LateUpdate() {
        Vector3 delta = Vector3.zero;

        float deltaX= lookAt.position.x - transform.position.x;
        //out of bounds to the right
        if(deltaX > boundX){
            delta.x =   deltaX-boundX;
        }
        //out of bounds to the left
        else if (deltaX < -boundX){
            delta.x=deltaX+boundX;
        }
        
        float deltaY= lookAt.position.y - transform.position.y;
        //out of bounds upwards
        if(deltaY > boundY){
            delta.y =   deltaY-boundY;
        }
        //out of bounds lewftwards
        else if (deltaY < -boundY){
            delta.y=deltaY+boundY;
        }

        transform.position+= new Vector3(delta.x, delta.y, 0);
    }


}
