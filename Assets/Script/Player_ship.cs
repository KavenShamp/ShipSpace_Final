using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_ship : MonoBehaviour
{

    public GameObject[] flames;
    public GameObject misile;
    public GameObject mine;
    public GameObject explosion;
    public GameObject explosion_dead;
    private GameObject Controller;
    private GameObject Camera;
    private Vector3 pos_misile;
    private Vector3 pos_mine;
    private float vel;
    public int fire_mode;
    public int mini_me;
    public BoxCollider coll_ship;
    public Slider life;
    private float largoShip;
    private float move_auto;

    //translate matriz
    private float[,] Matriz_pos;
    private float[,] matriz_Trans;
    public float[,] matriz_res;
    private Vector3 posM;

    //scale matriz
    private float[,] Matriz_fScale;
    private float[,] Matriz_nScale;
    private float[,] Matriz_cScale;
    private float[,] Matriz_endScale;
    public Vector3 scale;


    public float Move_auto
    {
        get { return move_auto; }
    }
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        Controller = GameObject.Find("MenuController");
        //Matriz de Translacion
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


        /* matrices de escalamiento */
        /** division - encogimiento**/
        Matriz_fScale = new float[4, 1];
        Matriz_fScale[3, 0] = 1;
        Matriz_nScale = new float[4, 4];
        Matriz_endScale = new float[Matriz_nScale.GetLength(0), Matriz_fScale.GetLength(1)];

        Matriz_nScale[0, 0] = 0.5f;
        Matriz_nScale[0, 1] = 0;
        Matriz_nScale[0, 2] = 0;
        Matriz_nScale[0, 3] = 0;

        Matriz_nScale[1, 0] = 0;
        Matriz_nScale[1, 1] = 0.5f;
        Matriz_nScale[1, 2] = 0;
        Matriz_nScale[1, 3] = 0;

        Matriz_nScale[2, 0] = 0;
        Matriz_nScale[2, 1] = 0;
        Matriz_nScale[2, 2] = 0.5f;
        Matriz_nScale[2, 3] = 0;

        Matriz_nScale[3, 0] = 0;
        Matriz_nScale[3, 1] = 0;
        Matriz_nScale[3, 2] = 0;
        Matriz_nScale[3, 3] = 1;

        Matriz_fScale[0, 0] = this.transform.localScale.x;
        Matriz_fScale[1, 0] = this.transform.localScale.y;
        Matriz_fScale[2, 0] = this.transform.localScale.z;

        /** multiplicacion - agrandamiento **/

        Matriz_cScale = new float[4, 4];

        Matriz_cScale[0, 0] = 2;
        Matriz_cScale[0, 1] = 0;
        Matriz_cScale[0, 2] = 0;
        Matriz_cScale[0, 3] = 0;

        Matriz_cScale[1, 0] = 0;
        Matriz_cScale[1, 1] = 2;
        Matriz_cScale[1, 2] = 0;
        Matriz_cScale[1, 3] = 0;

        Matriz_cScale[2, 0] = 0;
        Matriz_cScale[2, 1] = 0;
        Matriz_cScale[2, 2] = 2;
        Matriz_cScale[2, 3] = 0;

        Matriz_cScale[3, 0] = 0;
        Matriz_cScale[3, 1] = 0;
        Matriz_cScale[3, 2] = 0;
        Matriz_cScale[3, 3] = 1;


        vel = 40f;
        fire_mode = 1; // modo disparo
        mini_me = 1; // modo escalamiento
        largoShip = coll_ship.size.z;
    }

    // Update is called once per frame
    void Update()
    {
        mover();

        if (Input.GetKeyDown("f") && fire_mode == 1)
        {
            fire_mode *= -1;
        }
        else if (Input.GetKeyDown("f") && fire_mode != 1)
        {
            fire_mode *= -1;
        }

        if (Input.GetKeyDown("space"))
        {
            Disparo(fire_mode);
        }

        if (life.value == 0)
        {

            if (explosion_dead.GetComponent<ParticleSystem>().isStopped == true)
            {
                explosion_dead.GetComponent<ParticleSystem>().Play();
               
            }

            Controller.GetComponent<Menu_Controller>().loadScene("GameOver");
            dead();
        }

        /* activacion de metodo de encogimiento */

        if (Input.GetKeyDown("m") && mini_me == 1)
        {
            mini_me *= -1;
            largoShip = coll_ship.size.z * Matriz_nScale[0, 0];
            vel = 50f;
            MiniME();
        }
        else if (Input.GetKeyDown("m") && mini_me == -1)
        {
           
            largoShip = coll_ship.size.z;
            vel = 40f;
            mini_me *= -1;
            BigME();
        }

        Flames();
    }

    void Disparo(int fire_mode)
    {
        //Instancia distintos proyectiles de acuerdo al modo de disparo
        if (fire_mode == 1)
        {
            pos_misile = new Vector3(transform.position.x + largoShip, transform.position.y, transform.position.z);//calcular posisiotn con starSparrow_core

            Instantiate(misile, pos_misile, transform.rotation);
        }
        else if (fire_mode != 1)
        {
            pos_mine = new Vector3(transform.position.x + largoShip, transform.position.y, transform.position.z);//calcular posisiotn con starSparrow_core

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
   

    private void Flames()
    {
        if (life.value <= 0.80 && life.value > 0.60)
        {
            flames[0].SetActive(true);


        }
        if (life.value <= 0.60 && life.value > 0.40)
        {
            flames[1].SetActive(true);
        }
        if (life.value <= 0.40 && life.value > 0.30)
        {
            flames[2].SetActive(true);
        }
        if (life.value <= 0.20 && life.value > 0.05)
        {
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
                Matriz_pos[2, 0] = Matriz_pos[2, 0] - 0.1f;
            }
            else if (this.transform.position.z < 82)
            {
                Matriz_pos[2, 0] = Matriz_pos[2, 0] + 0.1f;
            }
        }
        else
        {
            matriz_Trans[2, 3] = Input.GetAxis("Vertical") * Time.deltaTime * vel;//z - limite z 150 - 80
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
        vel = 0;
        move_auto = 0;

        MeshRenderer[] mesh = GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < mesh.Length; i++)
        {
            mesh[i].enabled = false;
        }
        ParticleSystem[] particles = GetComponentsInChildren<ParticleSystem>();
        for (int i = 0; i < 16; i++)
        {

            particles[i].Stop();
        }
        BoxCollider[] box = GetComponentsInChildren<BoxCollider>();
        for (int i = 0; i < mesh.Length; i++)
        {
            box[i].enabled = false;
        }
        //Controller.GetComponent<Menu_Controller>().loadScene("GameOver");
        Invoke("destruir", 2f);
    }

    private void destruir()
    {
        Destroy(gameObject);
    }
    void MiniME()
    {
        for (int aux = 0; aux < Matriz_fScale.GetLength(1); aux++)
        {
            for (int i = 0; i < Matriz_nScale.GetLength(0); i++)
            {
                float Sum = 0f;
                for (int j = 0; j < Matriz_nScale.GetLength(1); j++)
                {
                    Sum += Matriz_nScale[i, j] * Matriz_fScale[j, aux];
                }
                Matriz_endScale[i, aux] = Sum;
            }
        }
        Matriz_fScale[0, 0] = Matriz_endScale[0, 0];
        Matriz_fScale[1, 0] = Matriz_endScale[1, 0];
        Matriz_fScale[2, 0] = Matriz_endScale[2, 0];

        scale = new Vector3(Matriz_fScale[0, 0], Matriz_fScale[1, 0], Matriz_fScale[2, 0]);

        transform.localScale = new Vector3(scale.x, scale.y, scale.z);
        
    }

    void BigME()
    {
        for (int aux = 0; aux < Matriz_fScale.GetLength(1); aux++)
        {
            for (int i = 0; i < Matriz_cScale.GetLength(0); i++)
            {
                float Sum = 0f;
                for (int j = 0; j < Matriz_cScale.GetLength(1); j++)
                {
                    Sum += Matriz_cScale[i, j] * Matriz_fScale[j, aux];
                }
                Matriz_endScale[i, aux] = Sum;
            }
        }
        Matriz_fScale[0, 0] = Matriz_endScale[0, 0];
        Matriz_fScale[1, 0] = Matriz_endScale[1, 0];
        Matriz_fScale[2, 0] = Matriz_endScale[2, 0];

        scale = new Vector3(Matriz_fScale[0, 0], Matriz_fScale[1, 0], Matriz_fScale[2, 0]);

        transform.localScale = new Vector3(scale.x, scale.y, scale.z);
        
    }

 
}