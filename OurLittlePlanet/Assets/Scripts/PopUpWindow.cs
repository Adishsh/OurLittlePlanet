using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpWindow : MonoBehaviour
{
    public GameObject prefab; //attach to this the prefab you want to instantiate
 
   // private GameObject instantiatedObject;

    //public GameObject Object;
    void OnMouseEnter()
    {
        //instantiatedObject = Instantiate(prefab, Object.transform.position, Quaternion.identity) as GameObject;
            prefab.gameObject.SetActive(true); 
      
            
                
    }

    
    void OnMouseExit()
    {
        prefab.SetActive(false);
     
    }
    
    
}
