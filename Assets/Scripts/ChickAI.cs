using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class ChickAI : MonoBehaviour
{
    public NavMeshAgent agent;
    private float _gapTime = 3.5f;
    
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _gapTime += Time.deltaTime;
        if (_gapTime >= Random.Range(2,_gapTime))
        {
            WalkAround();
        }
    }

    void WalkAround()
    {
        agent.SetDestination(GetRandomLocation());
        _gapTime = 0;
    }
    
    public Vector3 GetRandomLocation()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();
 
        int t = Random.Range(0, navMeshData.indices.Length - 3);
 
        Vector3 point = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[t]], navMeshData.vertices[navMeshData.indices[t + 1]], Random.value);
        point = Vector3.Lerp(point, navMeshData.vertices[navMeshData.indices[t + 2]], Random.value);
 
        return point;
    }
}
