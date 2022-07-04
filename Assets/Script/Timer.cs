using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    private float _time;
    public float _Time
    {
        get { return _time; }
    }
    void Start()
    {
        _time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if (_time > 2)
        {
            _time = 0;
        }

    }
}
