using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints : MonoBehaviour
{
    public LixoSpawnerController LixoSpawnerController;
    private void OnCollisionEnter(Collision collision) {
        
        if (collision.gameObject.CompareTag("Lixo")) {
            Destroy(collision.gameObject);
            LixoSpawnerController.AddToPoints(1);
        }
    }    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
