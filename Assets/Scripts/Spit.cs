using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spit : MonoBehaviour
{
    public ParticleSystem spitParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            Debug.Log(other.gameObject);
            Vector3 collisionPoint = other.ClosestPointOnBounds(transform.position);

            spitParticle.transform.position = collisionPoint;
            spitParticle.Play();

            Destroy(gameObject,0.5f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.gameObject);
            //Vector3 collisionPoint = other.contacts);
            ContactPoint contact = other.contacts[0];

            spitParticle.transform.position = contact.point;
            spitParticle.Play();

            Destroy(gameObject,0.5f);
        }
    }
}
