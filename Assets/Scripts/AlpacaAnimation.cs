using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlpacaAnimation : MonoBehaviour
{
    public GameObject tail;

    public GameObject earL;

    public GameObject earR;

    public Vector3 scaleChange;

    public Vector3 rotateChange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        earL.transform.Rotate(rotateChange);
        if (earL.transform.rotation.x > 45 || earL.transform.rotation.x <1)
        {
            rotateChange = -rotateChange;
        }
        
        tail.transform.localScale += scaleChange;

        if (tail.transform.localScale.y < 0.2f || tail.transform.localScale.y > 0.3f)
        {
            scaleChange = -scaleChange;
        }
    }
}
