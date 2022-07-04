using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mover_player : MonoBehaviour
{
    
    public GameObject[] flames;
    public GameObject misile;
    public GameObject mine;
    public GameObject explosion;
    public GameObject explosion_dead;
    private GameObject Camera;
    private Vector3 pos_misile;
    private Vector3 pos_mine;
    private float vel;
    public int fire_mode;
    public BoxCollider coll_ship;
    public Slider life;
    private float move_auto;

    //translate matriz
    private float[,] Matriz_pos;
    private float[,] matriz_Trans;
    public float[,] matriz_res;
    private Vector3 posM;

   
    public float Move_auto
    {
        get { return move_auto; }
    }
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        Matriz_pos = new float[4, 1];
        matriz_Trans = new float[4, 4];
        matriz_res = new float[matriz_Trans.GetLength(0), Matriz_pos.GetLength(1)];

        matriz_Trans[0, 0] = 1;
        matriz_Trans[0, 1] = 0;
        matriz_Trans[0, 2] = 0;

        matriz_Trans[1, 0] = 0;
        matriz_Trans[1, 1] = 1;
        matriz_Trans[1, 2] = 0;

        matriz_Trans[2, 0] = 0;
        matriz_Trans[2, 1] = 0;
        matriz_Trans[2, 2] = 1;

        matriz_Trans[3, 0] = 0;
        matriz_Trans[3, 1] = 0;
        matriz_Trans[3, 2] = 0;
        matriz_Trans[3, 3] = 1;

        Matriz_pos[0, 0] = this.transform.position.x;
        Matriz_pos[1, 0] = this.transform.position.y;
        Matriz_pos[2, 0] = this.transform.position.z;
        Matriz_pos[3, 0] = 1;

        vel = 30f;
        fire_mode = 1;
    }

    // Update is called once per frame
    void Update()
    {
        mover();

        if (Input.GetKeyDown("f") && fire_mode == 1)
        {
            fire_mode*=-1;
        } else if (Input.GetKeyDown("f") && fire_mode != 1)
        {
            fire_mode*=-1;
        }

        if (Input.GetKeyDown("space"))
        {
            Disparo(fire_mode);
        }
        if (life.value ==0)
        {

            if (explosion_dead.GetComponent<ParticleSystem>().isStopped == true)
            {
                explosion_dead.GetComponent<ParticleSystem>().Play();
            }
            /*else
            {
                explosion_dead.GetComponent<ParticleSystem>().Stop();
            }*/

            dead();
        }

        Flames();
    }

    void Disparo(int fire_mode)
    {
        if(fire_mode == 1)
        {
            pos_misile =new Vector3( transform.position.x+coll_ship.size.z,transform.position.y,transform.position.z);//calcular posisiotn con starSparrow_core

            Instantiate(misile, pos_misile,transform.rotation);
        } else if (fire_mode != 1)
        {
            pos_mine = new Vector3( transform.position.x + coll_ship.size.z, transform.position.y, transform.position.z);//calcular posisiotn con starSparrow_core

            Instantiate(mine, pos_mine, transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("bala"))
        {
            
            life.value -= col.GetComponent<stats_bala>().Damage;
            Instantiate(explosion, col.GetComponent<Transform>().position, Quaternion.Euler(0, 0, 0));
            explosion.SetActive(true);
           
   
            
        }
        if (col.CompareTag("Asteroid"))
        {
           life.value -= col.GetComponent<stats_asteroid>().Damage;
            Instantiate(explosion, col.GetComponent<Transform>().position, Quaternion.Euler(0, 0, 0));

            explosion.SetActive(true);
        }
        if (col.CompareTag("EnemyShip"))
        {
            life.value -= col.GetComponent<stats_shipE>().Damage;
            Instantiate(explosion, col.GetComponent<Transform>().position, Quaternion.Euler(0, 0, 0));

            explosion.SetActive(true);

        }
    }
    private void destruir_Explosion()
    {
        Destroy(gameObject);
    }

    private void Flames()
    {
        if (life.value <= 0.80 && life.value>0.60)
        {
            flames[0].SetActive(true);
          

        }
        if(life.value <= 0.60 && life.value>0.40)
        {
           flames[1].SetActive(true);
        }
        if(life.value<=0.40 && life.value > 0.30)
        {
            flames[2].SetActive(true);
        }
        if(life.value<=0.20 && life.value > 0.05) {
            flames[3].SetActive(true);
        }
    }
    private void mover()
    {
        if (this.transform.position.z >= 149 || this.transform.position.z <= 82)
        {
            matriz_Trans[2, 3] = 0;
            if (this.transform.position.z > 149)
            {
                Matriz_pos[2, 0] = Matriz_pos[2, 0]-0.1f;
            }
            else if(this.transform.position.z < 82)
            {
                Matriz_pos[2, 0] = Matriz_pos[2, 0] + 0.1f;
            }
        }
        else
        {
            matriz_Trans[2, 3] = Input.GetAxis("Vertical") * Time.deltaTime * vel;//z //limite z 150 - 80
        }

        if (Input.GetAxis("Horizontal") != 0 /*|| Input.GetAxis("Vertical")!=0*/)
        {
            
            if (Camera.GetComponent<mov_Camera>().Offset > 55)
            {
                matriz_Trans[0, 3] = 0;
            }
            else
            {
                move_auto = Input.GetAxis("Horizontal");
            }
        }
        else
        {
            move_auto = 0.9f;
        }


        for (int aux = 0; aux < Matriz_pos.GetLength(1); aux++)
        {
            for (int i = 0; i < matriz_Trans.GetLength(0); i++)
            {
                float Sum = 0f;
                for (int j = 0; j < matriz_Trans.GetLength(1); j++)
                {
                    Sum += matriz_Trans[i, j] * Matriz_pos[j, aux];
                }
                matriz_res[i, aux] = Sum;
            }
        }
        Matriz_pos[0, 0] = matriz_res[0, 0];
        Matriz_pos[1, 0] = matriz_res[1, 0];
        Matriz_pos[2, 0] = matriz_res[2, 0];

        
        matriz_Trans[0, 3] = move_auto * Time.deltaTime * vel;//x


        posM = new Vector3(Matriz_pos[0, 0], Matriz_pos[1, 0], Matriz_pos[2, 0]);

        transform.SetPositionAndRotation(posM, Quaternion.Euler(0, 90, 0));
    }
    private void dead()
    {
        MeshRenderer[] mesh = GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < mesh.Length; i++)
        {
            mesh[i].enabled = false;
        }
        ParticleSystem[] particles = GetComponentsInChildren<ParticleSystem>();
        for (int i = 0; i < 17; i++)
        {

            particles[i].Stop();
        }
        BoxCollider[] box = GetComponentsInChildren<BoxCollider>();
        for (int i = 0; i < mesh.Length; i++)
        {
            box[i].enabled=false;   
        }
        vel = 0;
        move_auto = 0;
      
        Invoke("destruir_Explosion", 2f);
    }
}
