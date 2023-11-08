using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class ChickGoToShooter : MonoBehaviour
{
    public Transform shooterEnter;
    public Transform shooterOut;
    public float speed;
    public float force;
    public GameObject newChick;

    public Rigidbody rb;
    public bool isGrounded = true;
    
    private void Awake()
    {
        if(!isGrounded){rb.AddForce(transform.right * force,ForceMode.Impulse);}
        shooterEnter = GameObject.Find("Enter").transform;
        shooterOut = GameObject.Find("Shooter").transform;
    }

    void Update ()   
    {  
        float step = speed * Time.deltaTime;  
        transform.LookAt(shooterEnter);
        gameObject.transform.localPosition=new Vector3(
            Mathf.Lerp(gameObject.transform.localPosition.x, shooterEnter.transform.position.x, step),
            Mathf.Lerp(gameObject.transform.localPosition.y, shooterEnter.transform.position.y, step),
            Mathf.Lerp(gameObject.transform.localPosition.z, shooterEnter.transform.position.z, step));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            Destroy(this.gameObject);
            Instantiate(newChick, shooterOut.position, quaternion.identity);
        }
    }
}
