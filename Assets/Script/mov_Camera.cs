using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov_Camera : MonoBehaviour
{
    private GameObject ship;
    private float posx;
    private float offset;
    private float Dist;
    public float Offset
    {
        get { return offset; }
    }
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Player");
        offset = ((30 * 100) / ship.GetComponent<Transform>().position.x);
        Dist = offset;
    }

    // Update is called once per frame
    void Update()
    {
        if(ship != null)
        {
            if (ship.GetComponent<Player_ship>().Move_auto > 0)
            {
                posx = ship.GetComponent<Transform>().position.x + offset;

                this.transform.position = new Vector3(posx, this.transform.position.y, this.transform.position.z);
                if (offset > Dist)
                {
                    offset -= 0.1f;
                }

            }
            else if (ship.GetComponent<Player_ship>().Move_auto < 0)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
                offset = this.transform.position.x - ship.GetComponent<Transform>().position.x;

            }
        }
     
        


    }
}
