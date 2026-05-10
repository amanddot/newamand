using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroylixo : MonoBehaviour
{
    public LixoSpawnerController LixoSpawnerController;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lixo"))
        {
            Destroy(collision.gameObject);
            LixoSpawnerController.RemoveFromPoints(1);
        }
    }

    void Start()
    {

    }
}
