using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShooterEnter : MonoBehaviour
{
    public GameObject newChick;

    public Transform shooter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chick"))
        {
            Destroy(other.gameObject);
            Instantiate(newChick, shooter.position, quaternion.identity);
        }
    }
}
