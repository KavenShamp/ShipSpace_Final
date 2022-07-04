using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim_player : MonoBehaviour
{
    private float ang_rotate;
    private float ang;
    private Vector3 Dist;
    private Vector3 posMouse;
    private int angle_redir;
    public Animator anim;
   // public Camera cams;
    void Start()
    {
        angle_redir = 180;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject cams = GameObject.FindWithTag("MainCamera");
        if (cams)
        {
            posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(posMouse);

        }
        ///GameObject cams = GameObject.FindWithTag("MainCamera");

        //posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Input.mousePosition;
        Dist = new Vector3( posMouse.x - this.transform.position.x, this.transform.position.y, posMouse.z - this.transform.position.z);
        Debug.Log(Dist);
        ang = Mathf.Atan2(Dist.x, Dist.z);
        ang_rotate = ang * (180 / Mathf.PI);// * -1;// + angle_redir;
        Quaternion angle = Quaternion.Euler(0, ang_rotate, 0);
        this.transform.rotation = angle;
       // Debug.Log(Dist);
        
        

    }
}
