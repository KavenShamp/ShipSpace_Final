using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auxiliar : MonoBehaviour
{
    private Vector3 posMouse;
    public Component pos;
   // public Camera cams;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* GameObject cams = GameObject.FindWithTag("MainCamera");
        if (cams)
        {
           
            //Debug.Log(posMouse);
            
        }*/
        posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //pos.transform.position = posMouse;
        pos.transform.position = new Vector3(posMouse.x, 0, posMouse.z) ;
    }

}
