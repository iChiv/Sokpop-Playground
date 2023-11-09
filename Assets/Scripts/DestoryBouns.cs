using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DestoryBouns : MonoBehaviour
{
    public GameObject carrot;
    public Transform carrotInChickBase;
    public Transform carrotInField;
    
    public int chickHit;
    public int chickHitGoal;

    public int cucurbitHit;
    public int cucurbitHitGoal;
    // Start is called before the first frame update
    private void Awake()
    {
        chickHit = 0;
        cucurbitHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (chickHit >= chickHitGoal)
        {
            chickHit = 0;
            Instantiate(carrot, carrotInChickBase.position, quaternion.identity);
        }

        if (cucurbitHit >= cucurbitHitGoal)
        {
            cucurbitHit = 0;
            Instantiate(carrot, carrotInField.position, quaternion.identity);
        }
    }
}
