using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Camera : MonoBehaviour
{
  // public Vector3 CameraRotation = new Vector3(-180,0,0);
  public GameObject Gameobj;
    void Update()
    {
     
       FlipCamera();
       //FlipCamera2();
       //FlipCamera3();

       
    }


    void FlipCamera()
    {
        if (Input.GetKeyDown("space"))
        {
            Gameobj.transform.Rotate(180, 0, 0);
          //  Gameobj.transform.Rotate(0, 0, 0);
          
            print("space key was pressed");
            
        }
        
    }
    
    
  /*  void FlipCamera2()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.rotation = Quaternion.Euler(-180, 0, 0);
            print("Rotation2");
        }

    }
*/
    /*  void FlipCamera()
      {
          if (Input.GetKeyDown(KeyCode.Space))
          {
              transform.rotation = Quaternion.Euler(CameraRotation.x -180 , CameraRotation.y , CameraRotation.z);
              print("Rotation");
          }
      }
      */
  
  
}
