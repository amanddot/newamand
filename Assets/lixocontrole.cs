using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lixocontrole : MonoBehaviour
{
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     float horizontalInput = Input.GetAxis("Horizontal");
     this.transform.position += new Vector3 (horizontalInput*velocity,0,0);
    }
}
