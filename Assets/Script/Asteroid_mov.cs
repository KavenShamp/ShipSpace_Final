using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_mov : MonoBehaviour
{
    private float vel;
    public float Vel
    {
        get { return vel; }
        set { vel = value; }
    }
    private Vector3 dir;
    private GameObject ship;
    public GameObject flame;

    private float ang;
    private float ang_rotate;
    void Start()
    {
        vel = 45f;
        ship = GameObject.Find("ship");
        dir = new Vector3(ship.transform.position.x - this.transform.position.x+70, ship.transform.position.y - this.transform.position.y, ship.transform.position.z - this.transform.position.z);
        rotate_flame();

    }

    void Update()
    {
    
        dir = dir.normalized;
        transform.Translate(dir.x * Time.deltaTime * vel, dir.y * Time.deltaTime * vel, dir.z * Time.deltaTime * vel);
        
    }
    void rotate_flame()
    {
        ang = Mathf.Atan2(dir.z, dir.x);
        ang_rotate = ang * (180 / Mathf.PI) + 90;
        flame.transform.Rotate(0, ang_rotate, 0);
      /*  if (this.transform.position.z < 120)
        {
            ang = Mathf.Atan2(dir.z, dir.x);
            ang_rotate = ang * (180 / Mathf.PI)+90;
            flame.transform.Rotate(0, ang_rotate, 0);
        }
        else
        {
            ang = Mathf.Atan2(dir.z, dir.x);
            ang_rotate = ang * (180 / Mathf.PI) + 90;
            flame.transform.Rotate(0, ang_rotate, 0);
        }*/
        
    }
}
