using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class special_ability : MonoBehaviour
{

    public float nuevaVelocidad = 20f;
    public float duracion = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Habilidad de super velocidad por tiempo limitado, tomando las pildoras moradas
        // Se asigna el tag 'Player' a la esfera(personaje)
        if (other.CompareTag("Player")) 
        {
            Move movimientoJugador = other.GetComponent<Move>();
            if (movimientoJugador != null)
            {
                movimientoJugador.aumentarVelocidadTemporal(nuevaVelocidad, duracion);
            }

            Destroy(gameObject); // Elimina la pildora de la escena
        }
    }
}
