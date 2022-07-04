using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] enemigo;
    private GameObject ship;
    private GameObject Timer;
    private int i;
    public float time_spawn = 3f;
    public float amount;
    private int a;
    private float posx;
    public float Spacing;
    private Vector3 Dist;
    public bool shipEnemy;
    void Start()
    {
        ship = GameObject.Find("ship");
        i = 0;
        posx = this.transform.position.x;



    }

    void Update()
    {
        ship = GameObject.Find("ship");
        Timer = GameObject.Find("Timer");
        if (ship != null)
        {
            Dist = new Vector3(ship.transform.position.x - this.transform.position.x, ship.transform.position.y - this.transform.position.y, ship.transform.position.z - this.transform.position.z);

        }
        if ((Timer.GetComponent<Timer>()._Time) % time_spawn == 0 && shipEnemy==false)
        {
            generar();
        }
        if (shipEnemy == true)
        {
            generar();
        }
    }

    private void generar()
    {
        

        if(ship != null )
        {
            if (enemigo.Length >= 1)
            {
                i = Random.Range(0, enemigo.Length);
            }


            if (amount != 0f && Dist.magnitude < 140)
            {

                while (a < amount)
                {
                    posx += Spacing;
                    Instantiate(enemigo[i], new Vector3(posx, this.transform.position.y, this.transform.position.z), this.transform.rotation);
                    a++;
                }
            }
            else if(amount==0 && Dist.magnitude < 340)
            {
                
                Instantiate(enemigo[i], this.transform.position, this.transform.rotation);
            }
        }
        
        
    }
}
