using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    private float _totalTime;
    private float _timePlayed;
    
    private GameObject _timer;

    private Timer _gameTimer;
    //
    // public Image timeMeter;

    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        _timer = GameObject.Find("Timer");
        _gameTimer = _timer.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        // _totalTime = _gameTimer.timeLimited;
         _timePlayed = _gameTimer.timeCountDown;
        // timeMeter.fillAmount = _timePlayed / _totalTime;

        if (_timePlayed > 0)
        {
            timerText.text = string.Format("{0:d2}:{1:d2}", (int)_timePlayed / 60, (int)_timePlayed % 60);
        }
        else
        {
            timerText.text = "00:00";
            timerText.color = Color.red;
        }

    }
}
