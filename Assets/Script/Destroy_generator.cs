using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_generator : MonoBehaviour
{
    private GameObject ship;
    private float Dist;
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(ship!= null)
        {
            Dist = ship.transform.position.x - this.transform.position.x;

        }

        if (Dist > 40)
        {
            Destroy(gameObject);
        }
    }
}
