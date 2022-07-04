using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats_bala : MonoBehaviour
{
    private float damage;
    public float Damage { get { return damage; } set { damage = value; } }
    // Start is called before the first frame update
    void Start()
    {
        damage = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
