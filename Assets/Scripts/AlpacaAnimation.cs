using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlpacaAnimation : MonoBehaviour
{
    [Header("AnimationGap")] 
    public float gap;
    private float gapTime;
    [Header("Objects")]
    public GameObject tail;
    public GameObject earL;
    public GameObject earR;

    [Header("TailScale")]
    public Vector3 scaleChange;

    [Header("EarRotation")]
    public Transform earL0;
    public Transform earR0;
    public Transform earL1;
    public Transform earR1;

    [Header("EarRotateAnimation")]
    public AnimationCurve curve;
    public float T;
    private float t;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gapTime += Time.deltaTime;
        if (gapTime >= gap)
        {
            AlpacaAnime();
            StartCoroutine(GapCoroutione());
        }

    }

    // IEnumerator EarCoroutine()
    // {
    //     earL.transform.rotation = Quaternion.Slerp(earL.transform.rotation, earL1.rotation, 1f);
    //     earR.transform.rotation = Quaternion.Slerp(earR.transform.rotation, earR1.rotation, 1f);
    //     yield return new WaitForSeconds(2f);
    //     // earL.transform.rotation = Quaternion.Slerp(earL.transform.rotation, earL0.rotation, 1f);
    //     // earR.transform.rotation = Quaternion.Slerp(earR.transform.rotation, earR0.rotation, 1f);
    //     yield return new WaitForSeconds(2f);
    // }

    IEnumerator GapCoroutione()
    {
        yield return new WaitForSeconds(5f);
        gapTime = 0;
    }

    public void AlpacaAnime()
    {
        T += speed * Time.deltaTime;
        T = Mathf.Clamp01(T);

        t = curve.Evaluate(T);
        if (T == 1 || T ==0)
        {
            speed = -speed;
        }
        // StartCoroutine(EarCoroutine());
        if (speed > 0)
        {
            earL.transform.rotation = Quaternion.Slerp(earL.transform.rotation, earL1.rotation, t);
            earR.transform.rotation = Quaternion.Slerp(earR.transform.rotation, earR1.rotation, t);
        }
        else
        {
            earL.transform.rotation = Quaternion.Slerp(earL.transform.rotation, earL0.rotation, t);
            earR.transform.rotation = Quaternion.Slerp(earR.transform.rotation, earR0.rotation, t);
        }
        
        tail.transform.localScale += scaleChange;
        if (tail.transform.localScale.y < 0.2f || tail.transform.localScale.y > 0.3f)
        {
            scaleChange = -scaleChange;
        }
    }
}
