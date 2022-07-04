using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_explosion_ship : MonoBehaviour
{
    private float Dist;
    private GameObject ship;
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
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

        if (Dist > 30)
        {
            Destroy(gameObject);
        }
    }
}
