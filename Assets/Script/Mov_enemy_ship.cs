using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_enemy_ship : MonoBehaviour
{
    public float vel = 4; //3 - 20
    public float amplitud = 8; //8
    public float frecuencia = 1.5f; //1.5 - 0.5
    public float centroZ; 
    private Vector3 pos; 
    private float sen;

    private Vector3 dir;
    private GameObject ship;

    void Start()
    {
        centroZ = transform.position.z;
        ship = GameObject.Find("ship");
       

    }

    void Update()
    {
        if(ship != null)
        {
            dir = new Vector3(ship.transform.position.x - this.transform.position.x, ship.transform.position.y - this.transform.position.y, ship.transform.position.z - this.transform.position.z);

        }
        pos = transform.position; 
        sen = Mathf.Sin(pos.x * frecuencia) * amplitud + centroZ; 
        pos.x -= vel * Time.deltaTime;
        pos.y += dir.normalized.y;
        pos = new Vector3(pos.x, pos.y, sen); 
        transform.position = pos; 



    }
}
