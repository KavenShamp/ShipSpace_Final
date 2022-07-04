using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats_asteroid : MonoBehaviour
{
    private float damage;
    public float Damage { get { return damage; } set { damage = value; } }
    // Start is called before the first frame update
    void Start()
    {
        damage = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
