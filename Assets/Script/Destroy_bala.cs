using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_bala : MonoBehaviour
{
    private float Dist;
    private GameObject ship;
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if(ship != null)
        {
            Dist = ship.transform.position.x - this.transform.position.x;

        }
        else
        {
            Destroy(gameObject);
        }


        if (Dist >45)
        {
            Destroy(gameObject);
        }
        if (Dist<-150)
        {
            Destroy(gameObject);
        }
        if (this.transform.position.z < 60)
        {
            Destroy(gameObject);
        }
        if (this.transform.position.z > 172)
        {
            Destroy(gameObject);
        }
       /* Debug.Log(Mathf.Sqrt(Mathf.Pow(Dist_col.x, 2) + Mathf.Pow(Dist_col.y, 2) + Mathf.Pow(Dist_col.z, 2)));
        Dist_col = new Vector3(ship.transform.position.x - this.transform.position.x, ship.transform.position.y - this.transform.position.y, ship.transform.position.z - this.transform.position.z);
        if (Mathf.Sqrt(Mathf.Pow(Dist_col.x, 2) + Mathf.Pow(Dist_col.y, 2) + Mathf.Pow(Dist_col.z, 2)) <= 8.5)
        {
            Destroy(gameObject);
        }*/


    }
    private void OnTriggerEnter(Collider other)
    {
       
            Destroy(gameObject);
        
        
    }
}
