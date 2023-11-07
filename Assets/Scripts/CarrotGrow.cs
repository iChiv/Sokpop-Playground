using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotGrow : MonoBehaviour
{
    public Animator growthAnimator; 

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spit"))
        {
            growthAnimator.SetTrigger("Grow");

            Destroy(other.gameObject);
        }
    }
}
