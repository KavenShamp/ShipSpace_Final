using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Over : MonoBehaviour
{
    public GameObject GameOverImagen;
    public static GameObject GameOverStatic;

    public GameObject BotonRei;
    public static GameObject BotonReiStatic;

    public GameObject BotonSalir;
    public static GameObject BotonSalirStatic;
    // Start is called before the first frame update
    void Start()
    {

        Over.GameOverStatic = GameOverImagen;
        Over.GameOverStatic.gameObject.SetActive(false);

        Over.BotonReiStatic = BotonRei;
        Over.BotonReiStatic.gameObject.SetActive(false);

        Over.BotonSalirStatic = BotonSalir;
        Over.BotonSalirStatic.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Show()
    {
        Over.GameOverStatic.gameObject.SetActive(true);
        Over.BotonReiStatic.gameObject.SetActive(true);
        Over.BotonSalirStatic.gameObject.SetActive(true);
    }
}
