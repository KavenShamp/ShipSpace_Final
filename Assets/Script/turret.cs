using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    private float ang_rotate;
    private float ang;
    private Vector3 Dist;
    private GameObject ship;
    public Component torret;
    private int angle_redir;
    public GameObject bala;
    public Animator anim;
    public GameObject canon;
    private GameObject Timer;

    
    // Start is called before the first frame update
    void Start()
    {
       
        angle_redir=180;
  
    }

    // Update is called once per frame
    void Update() 
    {
        ship = GameObject.Find("ship");
        Timer = GameObject.Find("Timer");

        if (ship!= null)
        {
            Dist = new Vector3(ship.transform.position.x - torret.transform.position.x, ship.transform.position.y - torret.transform.position.y, ship.transform.position.z - torret.transform.position.z);
            ship.GetComponent<Player_ship>().misile.GetComponent<misile>().dist = Dist * -1;
        }
      
        ang = Mathf.Atan2(Dist.z,Dist.x);
        ang_rotate = ang *(180/Mathf.PI)*-1+angle_redir;
        Quaternion angle = Quaternion.Euler(0,ang_rotate,0);
        this.transform.rotation = angle;

        if((Timer.GetComponent<Timer>()._Time) % 2 == 0){
            Disparo();
        }
        

    

    }

    void Disparo()//bool cond_anim
    {
        if(ship != null && Dist.magnitude<140 )
        {

            Vector3 pos_bala = new Vector3(this.transform.position.x - (this.transform.position.x - canon.transform.position.x), this.transform.position.y - (this.transform.position.y - canon.transform.position.y), this.transform.position.z - (this.transform.position.z - canon.transform.position.z));
            bala.GetComponent<mov_bala>().distancia = new Vector3(Dist.x, Dist.y + (this.transform.position.y - canon.transform.position.y), Dist.z);
          
            Instantiate(bala, pos_bala, Quaternion.Euler(0, 0, 0));
            // anim.SetBool("shoot", cond_anim);
            //anim.SetBool("shoot", false);
            //Invoke("Disparo", 2f);
            //Bala2 myBala = new Bala2; forma de crear un nuevo objeto
        }
    }
}
