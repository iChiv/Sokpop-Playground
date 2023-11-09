using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    private float _totalTime;
    private float _timePlayed;
    
    private GameObject _timer;

    private Timer _gameTimer;

    public Image timeMeter;
    // Start is called before the first frame update
    void Start()
    {
        _timer = GameObject.Find("Timer");
        _gameTimer = _timer.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        _totalTime = _gameTimer.timeLimited;
        _timePlayed = _gameTimer.timeCountDown;
        timeMeter.fillAmount = _timePlayed / _totalTime;

    }
}
