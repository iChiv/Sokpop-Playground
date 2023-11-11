using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeMenu : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ExitGame()
    {
        //not useful in WebGL Build
        Application.Quit();
    }
}
