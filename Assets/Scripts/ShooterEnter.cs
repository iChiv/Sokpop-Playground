using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShooterEnter : MonoBehaviour
{
    public GameObject newChick;

    public Transform shooter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chick"))
        {
            Debug.Log("Enter");
            Destroy(other.gameObject);
            Instantiate(newChick, shooter.position, quaternion.identity);
        }
    }
}
