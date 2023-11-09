using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spit : MonoBehaviour
{
    public ParticleSystem spitParticle;

    //private void Awake()
    //{
    //    Rigidbody rb = GetComponent<Rigidbody>();
    //    rb.velocity = transform.right * 10;
    //}

    private void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {

        Vector3 collisionPoint = other.ClosestPointOnBounds(transform.position);

        spitParticle.transform.position = collisionPoint;
        spitParticle.Play();

        Destroy(gameObject);

    }
}
