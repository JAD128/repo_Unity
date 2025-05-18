using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    // Habilidad de Velocidad
    private float velocidadOriginal = 5f;

    public float horizontalInput;
    public float verticalInput; 

    //Variable tipo GameObject - guarda la esfera
    public GameObject miObjeto;

    public GameObject miOtroObjeto;

    // Variable interactuar desde otra clase
    public bool cambiaObjeto = false;

    // Escudo
    public bool escudoActivo = false;
    private bool puedeActivarEscudo = true;
    public GameObject efectoEscudo;

    private float duracionEscudo = 5f; // Duración del escudo 
    public float tiempoDeRecarga = 10f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate(miObjeto, transform.position, Quaternion.identity);
            cambiaMiObjeto();
        }

        horizontalInput = Input.GetAxis("Horizontal"); //Nombre tiene que ser igual .-.
        //horizontalInput = Input.GetAxis("Mouse X");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        verticalInput = Input.GetAxis("Vertical"); //Nombre tiene que ser igual .-.
        //verticalInput = Input.GetAxis("Mouse Y");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        // Limites en z

        if (transform.position.z > 13.23f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 13.23f);
        }
        else if (transform.position.z < -23.12f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -23.12f);
        }

        // Limites en X

        if (transform.position.x < -7.15f)
        {
            transform.position = new Vector3(-7.15f, transform.position.y, transform.position.z);
        } 
        else if (transform.position.x > 5.71f)
        {
            transform.position = new Vector3(5.71f, transform.position.y, transform.position.z);
        }

        // Activar escudo con tecla 'E' 

        if (Input.GetKeyDown(KeyCode.E) && puedeActivarEscudo)
        {
            StartCoroutine(ActivarEscudo());
        }
    }

    public void cambiaMiObjeto()
    {
        if (cambiaObjeto == true)
        {
            Instantiate(miOtroObjeto, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(miObjeto, transform.position, Quaternion.identity);
        }
    }

    // Métodos de la habilidad especial (Super velocidad)
    public void aumentarVelocidadTemporal(float nuevaVelocidad, float duracion)
    {
        StopAllCoroutines(); 
        StartCoroutine(VelocidadTemporalCoroutine(nuevaVelocidad, duracion));
    }

    private IEnumerator VelocidadTemporalCoroutine(float nuevaVelocidad, float duracion)
    {
        speed = nuevaVelocidad;
        Debug.Log("¡Velocidad aumentada! | Velocidad: " + speed + nuevaVelocidad);
        yield return new WaitForSeconds(duracion);
        speed = velocidadOriginal;
        Debug.Log("¡Velocidad restaurada! | Velocidad: " + speed);
    }

    private IEnumerator ActivarEscudo()
    {
        escudoActivo = true;
        puedeActivarEscudo = false;
        GameObject escudoInstanciado = null;

        Debug.Log("¡Escudo activado!");
        if (efectoEscudo != null)
            
        {
            escudoInstanciado = Instantiate(efectoEscudo, transform.position, Quaternion.identity); // Instancia el clon 
        }

        yield return new WaitForSeconds(duracionEscudo);

        escudoActivo = false;
        Debug.Log("Escudo desactivado.");
        if (efectoEscudo != null)
        {
            Destroy(escudoInstanciado); //Elimina el clon
        }

        // Inicia tiempo de recarga
        yield return new WaitForSeconds(tiempoDeRecarga);
        puedeActivarEscudo = true;
        Debug.Log("Escudo recargado. Puedes usarlo de nuevo.");
    }

}
