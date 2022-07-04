using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuVivo : MonoBehaviour
{
    float mousePosx;
    float mousePosy;

    [SerializeField] float movementQuantity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosx= Input.mousePosition.x;
        mousePosy= Input.mousePosition.y;

        this.GetComponent<RectTransform>().position = new Vector2(
            (mousePosx / Screen.width) * movementQuantity + (Screen.width/2),
            (mousePosy / Screen.height) * movementQuantity +(Screen.height/2));
    }
}
