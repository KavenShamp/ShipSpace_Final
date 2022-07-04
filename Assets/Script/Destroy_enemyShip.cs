using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_enemyShip : MonoBehaviour
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
        if (ship != null)
        {
            Dist = ship.transform.position.x - this.transform.position.x;

        }
        else
        {
            Destroy(gameObject);
        }


        if (Dist > 40)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);


    }
}
