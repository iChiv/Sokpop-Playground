using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool playing;
    public float timeLimited;

    public float timeCountDown;
    // Start is called before the first frame update
    void Start()
    {
        timeCountDown = timeLimited;
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            timeCountDown -= Time.deltaTime;
            if (timeCountDown <= 0)
            {
                GameFinished();
            }
        }
        else
        {
            timeCountDown = timeLimited;
        }
    }

    public void GameFinished()
    {
        Debug.Log("Happy time ends now~");
    }
}
