using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SpitController : MonoBehaviour
{
    public GameObject spitPrefab;

    public Transform spitPoint;

    public float spitSpeed;

    //public Camera camera;

    [Range(0,100)]public int spitTime = 5;

    public bool isDrink=false;

    public LayerMask spitLayer;

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
        var _camera = Camera.main;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        

        if(Physics.Raycast(ray,out hit,spitLayer))
        {
            Vector3 direction = (hit.point - spitPoint.position).normalized;

            //Instantiate(spitPrefab, spitPoint.position, Quaternion.LookRotation(direction));

            GameObject spitInstance = Instantiate(spitPrefab, spitPoint.position, Quaternion.LookRotation(direction));

            Rigidbody spitRigidbody = spitInstance.GetComponent<Rigidbody>();

            // spitRigidbody.velocity = direction * spitSpeed;
            spitRigidbody.AddForce(spitPoint.right * spitSpeed,ForceMode.Impulse);
        }

    }
}
