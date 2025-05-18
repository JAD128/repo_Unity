using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class move_object : MonoBehaviour
{
    public float speed = 5.0f;
<<<<<<< HEAD
    public float posZ = 13.23f;
=======
    public float posZ = 0f;
>>>>>>> refs/remotes/origin/Mi_proyectito
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); 
        if (transform.position.z > 13.23f)
        {
            Destroy(this.gameObject);
        }
    }
}
