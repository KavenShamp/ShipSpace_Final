using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_asteroid : MonoBehaviour
{
    public GameObject Dust_explosion;
    public GameObject flame;
    private GameObject ship;
    private float Dist;
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.transform.position.y < 0 + this.transform.localScale.magnitude)
        {
            destruir();
        }
        if (ship != null)
        {
            Dist = ship.transform.position.x - this.transform.position.x;

        }
        else
        {
            destruir();
        }


        if (Dist > 70)
        {
            Destroy(gameObject);
        }
    }

    void destruir()
    {
        GetComponent<MeshRenderer>().enabled = false;
        flame.GetComponent<ParticleSystem>().Stop();

        if (Dust_explosion.GetComponent<ParticleSystem>().isStopped == true)
        {
            Dust_explosion.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            Dust_explosion.GetComponent<ParticleSystem>().Stop();
        }
       
        GetComponent<Asteroid_mov>().Vel = 0;
        Invoke("destruccion", 2f);
    }
    void destruccion()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Asteroid_mov>().Vel = 0;
        GetComponent<MeshRenderer>().enabled = false;
        flame.GetComponent<ParticleSystem>().Stop();
        Invoke("destruccion", 1.3f);

        
        
    }

}
