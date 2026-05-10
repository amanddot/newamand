using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints : MonoBehaviour
{
    public LixoSpawnerController LixoSpawnerController;
    public AudioSource source;
    private void OnCollisionEnter(Collision collision) {
        
        if (collision.gameObject.CompareTag("Lixo")) {
            Destroy(collision.gameObject);
            source.Play();
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
