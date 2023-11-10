using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    private GameObject _timer;

    private Timer _gameTimer;
    // Update is called once per frame

    private void Awake()
    {
        _timer = GameObject.Find("Timer");
        _gameTimer = _timer.GetComponent<Timer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            menu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void RestartLevel()
    {
        var currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    public void ResumeLevel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnToWelcome()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
