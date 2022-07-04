using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu_Controller : MonoBehaviour
{


    public Animator transicion;
    private float _time;
 

    public void loadScene(string scene)
    {
        StartCoroutine(Transiciona(scene));
    }

    IEnumerator Transiciona(string scene)
    {
        if(scene == "GameOver")
        {
            _time = 2f;
        }
        transicion.SetTrigger("salida");
        yield return new WaitForSeconds(_time);
        SceneManager.LoadScene(scene);
    }
  
    public void ExitGame()
    {
        Application.Quit();
    }

}
