using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisione con: " + other.name);
        //Acceder a las variables y metodos de la clase player (Move)
        Move myObject = other.GetComponent<Move>();
        if (myObject != null)
        {
            // Alternar el valor de cambiaObjeto
            myObject.cambiaObjeto = !myObject.cambiaObjeto;

            // Cambiar el objeto
            myObject.cambiaMiObjeto();
            Debug.Log("Cambio de balas");

            // Destruye el objeto que colisiona (opcional según tu lógica)
            Destroy(this.gameObject);
        }
    }
}
