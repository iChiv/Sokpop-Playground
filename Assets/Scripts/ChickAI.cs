using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class ChickAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 walkPoint;
    //public GameObject newChick;
    //public Transform shooter;
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        BackToShooter();
    }

    void BackToShooter()
    {
        transform.LookAt(walkPoint);
        agent.SetDestination(walkPoint);
    }

    private void OnDestroy()
    {
        //SFX
        //VFX
        //newChick
        
    }
}
