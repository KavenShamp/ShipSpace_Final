using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misile : MonoBehaviour
{
    private float vel;
    public Vector3 dist;
    public GameObject explosion;
    public GameObject explosionBala;
    public GameObject explosionAsteroid;
    public GameObject explosionShip;
    private float pos_ini;
    // Start is called before the first frame update
    void Start()
    {
        vel = 90F;
        pos_ini = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()

    {

        dist = dist.normalized;
        this.transform.Translate(0, dist.y*Time.deltaTime, vel * Time.deltaTime);
        if (this.transform.position.x > pos_ini + 130)
        {
           Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag=="Turret")
        {
            GetComponent<MeshRenderer>().enabled = false;
            vel = 0;
            Destroy(col.gameObject);    
            explosion.SetActive(true);
            explosion.GetComponent<ParticleSystem>().Play();
     
            Invoke("destruir", 2f);
            
        }
        if (col.tag == "bala")
        {
            GetComponent<MeshRenderer>().enabled = false;
            vel = 0;
            Destroy(col.gameObject);
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
