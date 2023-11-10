using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSwag : MonoBehaviour
{
    private Rigidbody rb;
    public int force = 4; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}
