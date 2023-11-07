using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SpitController : MonoBehaviour
{
    public GameObject spitPrefab;
    public Transform spitPoint;
    public float spitSpeed;

    public float spitTime = 5;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&spitTime>0)
        {
            SpawnSpit();
            spitTime = spitTime - 1;
        }
    }
    void SpawnSpit()
    {
        GameObject spit = Instantiate(spitPrefab, transform.position, transform.rotation);
        Rigidbody spitRigidbody = spit.GetComponent<Rigidbody>();
        spitRigidbody.velocity = transform.right * spitSpeed;

    }


}
