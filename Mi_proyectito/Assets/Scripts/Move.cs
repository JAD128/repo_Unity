using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    public float horizontalInput;
    public float verticalInput;

    //Variable tipo GameObject - guarda la esfera
    public GameObject miObjeto;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(miObjeto, transform.position, Quaternion.identity);
            //cambiarMiObjeto();
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



    }
}
