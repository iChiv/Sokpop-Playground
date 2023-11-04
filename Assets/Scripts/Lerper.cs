using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerper : MonoBehaviour
{
    [Header("Object")]
    public Transform Object;
    public Transform Transform0;
    public Transform Transform1;
    
    [Header("Movement")]
    public AnimationCurve Curve;
    [Range(0,1)]
    public float T;
    public float Speed; // Filling Per second





    // Update is called once per frame
    void Update()
    {
        T += Speed * Time.deltaTime;
        T = Mathf.Clamp01(T);

        float t = Curve.Evaluate(T);
        Object.position = Vector3.Lerp(Transform0.position, Transform1.position, t);
        Object.rotation = Quaternion.Slerp(Transform0.rotation, Transform1.rotation, t);
    }

    public void To0(float speed = 1f)
    {
        Speed = -speed;
    }
    public void To1(float speed = 1f)
    {
        Speed = +speed;
    }
}
