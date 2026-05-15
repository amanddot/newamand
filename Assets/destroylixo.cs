using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLixo : MonoBehaviour
{
    public LixoSpawnerController lixoSpawnerController;

    private void OnCollisionEnter(Collision collision) 
    {
        // Opcional: Verifica se o objeto que colidiu tem a tag "Lixo"
        if (collision.gameObject.CompareTag("Lixo")) 
        {
            Destroy(collision.gameObject);

            if (lixoSpawnerController.points > 0) 
            {
                lixoSpawnerController.AddToPoints(-1);
            }
        }
    }
}