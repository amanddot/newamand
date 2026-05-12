using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLixo : MonoBehaviour
{
    // References
    private void OnCollisionEnter(Collision collision) 
    {
        // Optional: Check if the entering object is the Player
        if (collision.gameObject.CompareTag("Lixo")) 
        {
            Destroy(collision.gameObject);
        }
    }
}
