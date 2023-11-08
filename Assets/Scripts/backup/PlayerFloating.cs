using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Diagnostics;

public class PlayerFloating : MonoBehaviour
{
    [SerializeField] public float springForce;
    [SerializeField] public float rideSpringDamper;
    [SerializeField] public float rideSpringForce;
    [SerializeField] public float floatHeight;
    [SerializeField] public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 vel = rb.velocity;
            Vector3 rayDir = transform.TransformDirection(Vector3.down);

            Vector3 otherVel = Vector3.zero;
            Rigidbody hitBody = hit.collider.gameObject.GetComponent<Rigidbody>();
            if (hitBody != null)
            {
                otherVel = hitBody.velocity;
            }

            float rayDirVel = Vector3.Dot(rayDir, vel);
            float otherDirVel = Vector3.Dot(rayDir, otherVel);

            float relVel = rayDirVel - otherDirVel;

            float x = hit.distance - floatHeight;

            float springForce = (x * rideSpringForce) - (relVel * rideSpringDamper);
            
            rb.AddForce(rayDir * springForce);

            if (hitBody != null)
            {
                hitBody.AddForceAtPosition(rayDir * -this.springForce, hit.point);
            }
            
            Debug.DrawLine(ray.origin, hit.point, Color.magenta);
        }

    }

    // public void UpdateUprightForce(float elapsed)
    // {
    //     Quaternion characterCurrent = transform.rotation;
    //     // Quaternion toGoal = ShortestRotation()
    //
    //     Vector3 rotAxis;
    //     float rotDegrees;
    // }
    
    public static Quaternion ShortestRotation(Quaternion a, Quaternion b)
    {
        if (Quaternion.Dot(a, b) < 0)
        {
            return a * Quaternion.Inverse(Multiply(b, -1));
        }
        else return a * Quaternion.Inverse(b);
    }
    
    public static Quaternion Multiply(Quaternion input, float scalar)
    {
        return new Quaternion(input.x * scalar, input.y * scalar, input.z * scalar, input.w * scalar);
    }
}
