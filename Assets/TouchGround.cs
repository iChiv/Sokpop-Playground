using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchGround : MonoBehaviour
{
    public ChickGoToShooter goToShooter;
    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log(other.gameObject);
        if (other.gameObject.CompareTag("Ground"))
        {
            goToShooter.enabled = true;
            goToShooter.isGrounded = true;
        }
        else
        {
            goToShooter.isGrounded = false;
        }
    }
}
