using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroylixo : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lixo"))
        {
            Destroy(collision.gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {
    
    }
}
