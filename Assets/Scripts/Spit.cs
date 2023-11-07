using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
    public ParticleSystem spitParticle;


    private void OnTriggerEnter(Collider other)
    {
        string collidedObjectName = other.gameObject.name;
        Debug.Log("Collided with: " + collidedObjectName);

        Vector3 collisionPoint = other.ClosestPointOnBounds(transform.position);
        spitParticle.transform.position = collisionPoint;
        spitParticle.Play();

        //if (other.CompareTag("Carrot"))
        //{
           
        //    //ÂÜ²·Éú³¤

        //}

        Destroy(gameObject);

    }
}
