using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceAwake : MonoBehaviour
{
    private Rigidbody _rb;
    public float force;
    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(transform.right * force,ForceMode.Impulse);
    }
}
