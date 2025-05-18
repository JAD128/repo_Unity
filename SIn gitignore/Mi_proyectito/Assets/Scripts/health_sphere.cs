using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_sphere : MonoBehaviour
{

    public int vida = 3;
    public GameObject miPersonaje;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Reduce la vida del jugador(esfera) cada vez que este choca con uno de los obstaculos(bloques)
        // El jugador cuenta con 3 vidas, si choca 3 veces el jugador se destruira y el juego se da por terminado
        // Si el escudo está activado el jugador no pierde vidas.
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            Move movimiento = GetComponent<Move>();
            if (movimiento != null && movimiento.escudoActivo)
            {
                Debug.Log("¡Obstáculo bloqueado con escudo!");
                return; // No quitar vida
            } 

            vida--;
            Debug.Log("Vida del jugador: " + vida);

            if (vida <= 0)
            {
                Debug.Log("¡El jugado ha muerto! Juego terminado! :'(");
                Destroy(gameObject);
            }

        }
        
            

    }
}
