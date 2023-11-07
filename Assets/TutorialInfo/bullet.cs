using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Power = 10;
    public float Angle = 45;
    public float Gravity = -10;

    private Vector3 MoveSpeed;//初速度向量
    private Vector3 GritySpeed = Vector3.zero;//重力的速度向量，t时为0
    private float dTime;//已经过去的时间
    private Vector3 currentAngle;

    void Start()
    {
        MoveSpeed = Quaternion.Euler(new Vector3(0, 0, Angle)) * Vector3.right * Power;
        currentAngle = Vector3.zero;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //v = at ;
        GritySpeed.y = Gravity * (dTime += Time.fixedDeltaTime);
        //位移模拟轨迹
        transform.position += (MoveSpeed + GritySpeed) * Time.fixedDeltaTime;
        currentAngle.z = Mathf.Atan((MoveSpeed.y + GritySpeed.y) / MoveSpeed.x) * Mathf.Rad2Deg;
        transform.eulerAngles = currentAngle;
        
    }
}
