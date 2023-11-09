using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CarrotGrow : MonoBehaviour
{
    public GameObject carrot;
    public Lerper lerper;
    public float decay;

    public float growProcess;
    public float growStage;

    private void Update()
    {
        
        if (growStage >= growProcess-0.2f)
        {
            lerper.To1(0.5f);
            Destroy(this.gameObject);
            Instantiate(carrot, this.transform.position, quaternion.identity);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Spit"))
        {
            growStage += 1;
            Destroy(other.gameObject);
        }
    }
}
