using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SpitController : MonoBehaviour
{
    public GameObject spitPrefab;

    public Transform spitPoint;

    public float spitSpeed;

    public Camera camera;

    public float spitTime = 5;

    public bool isDrink=false;

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
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        

        if(Physics.Raycast(ray,out hit))
        {
            Vector3 direction = (hit.point - spitPoint.position).normalized;

            //Instantiate(spitPrefab, spitPoint.position, Quaternion.LookRotation(direction));

            GameObject spitInstance = Instantiate(spitPrefab, spitPoint.position, Quaternion.LookRotation(direction));

            Rigidbody spitRigidbody = spitInstance.GetComponent<Rigidbody>();

            spitRigidbody.velocity = direction * spitSpeed;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (isDrink&&Input.GetMouseButton(1))
        {
            Debug.Log("喝到水了");
            Drink();
        }
    }

    void Drink()
    {
        
        //播放喝水动画
        spitTime = 5;

    }

}
