using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rig;

    public float jumpForce;
    // Animator animator;
    public float speed = 5.0f;
    // public AudioClip clipFoot;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        // animator = GetComponent<Animator>();
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(transform.up * jumpForce);
        }
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        Vector3 dirWorld = Camera.main.transform.TransformDirection(dir);
        dirWorld.y = 0;
        dirWorld.Normalize();
        transform.LookAt(dirWorld + transform.position);
        
        Vector3 curVel = dirWorld * speed;
        curVel.y = rig.velocity.y;
        rig.velocity = curVel;
        // animator.SetFloat("Speed", dirWorld.magnitude);

    }
    // void playFootSound()
    // {
    //     AudioSource.PlayClipAtPoint(clipFoot, transform.position);
    // }
}
