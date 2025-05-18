using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_clase : MonoBehaviour
{
    public float posX = -1.18f;
    public float posY = 8.26f;
    public float posZ = 19.54f;
    void Start()
    {
        //Debug.Log("Mi nombre es: " + name);
        //Debug.Log("Pocisión: " + transform.position.x);
        //Debug.Log("Pocisiones: " + transform.position);

        transform.position = new Vector3(posX,posY,posZ);
        Debug.Log("Pocisión:" + transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Hola_munde");

    }
}
