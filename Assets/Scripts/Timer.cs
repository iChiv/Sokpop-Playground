using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool playing;
    [Header("Play Time Limit")]
    public float timeLimited;
    [Range(0,600)]
    public float timeCountDown;

    public GameObject gameOver;
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
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        gameOver.SetActive(true);
        playing = false;
        
    }
}
