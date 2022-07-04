using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mine : MonoBehaviour
{
    public float vel;
    public float frecuencia;
    public float amplitud;
    public float centroZ;
    private Vector3 pos;
    private float sen;
    public GameObject explosion;
    public GameObject explosionBala;
    public GameObject explosionAsteroid;
    public GameObject explosionShip;
    private float pos_ini;
    void Start()
    {
        vel = 45;
        frecuencia = 0.35f;
        amplitud = 3;
        centroZ = transform.position.z;
        pos_ini = this.transform.position.x;
    }

    void Update()
    {
        pos = transform.position;
        sen = Mathf.Sin(pos.x * frecuencia) * amplitud;
        pos.x += vel * Time.deltaTime;
        pos = new Vector3(pos.x, pos.y, sen + centroZ);
        transform.position = pos;
        
        if (this.transform.position.x > pos_ini +250)
        {
           Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag=="Turret")
        {
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(col.gameObject);   
            vel = 0; 
            explosion.SetActive(true);
            explosion.GetComponent<ParticleSystem>().Play();
     
            Invoke("destruir", 2f);            
        }
        if (col.tag == "bala")
        {
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(col.gameObject);
            vel = 0;
            explosionBala.SetActive(true);
            explosionBala.GetComponent<ParticleSystem>().Play();

            Invoke("destruir", 2f);

        }
        if (col.tag == "Asteroid")
        {
            GetComponent<MeshRenderer>().enabled = false;
            vel = 0;
            Destroy(col.gameObject);
            explosionAsteroid.SetActive(true);
            explosionAsteroid.GetComponent<ParticleSystem>().Play();

            Invoke("destruir", 2f);

        }
        if (col.tag == "EnemyShip")
        {
            GetComponent<MeshRenderer>().enabled = false;
            vel = 0;
            Destroy(col.gameObject);
            explosionShip.SetActive(true);
            explosionShip.GetComponent<ParticleSystem>().Play();

            Invoke("destruir", 2f);

        }

    }

    private void destruir()
    {
        Destroy (gameObject);
    }
}
