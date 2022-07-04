using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov_bala : MonoBehaviour
{
    private float vel;
    private Vector3 der;
    public Vector3 distancia;
   
    /*public Vector3 Distancia
    {
        get { return distancia; }
        set {  distancia = value; }
    }*/


    // Start is called before the first frame update
    void Start()
    {
        vel = 40f;
    }
    // Update is called once per frame
    void Update()
    {


       
        der = distancia.normalized;
      
        transform.Translate(der.x * Time.deltaTime * vel, der.y * Time.deltaTime * vel, der.z * Time.deltaTime * vel);
       
       
    }
    
   
}
