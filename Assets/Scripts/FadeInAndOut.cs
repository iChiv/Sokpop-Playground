using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeInAndOut : MonoBehaviour
{
    private float fadeSpeed = 1.5f;
    private bool sceneStarting = true;
    private RawImage backImage;

    void Start()
    {
        backImage = this.GetComponent<RawImage>();
        backImage.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    void Update()
    {
        if (sceneStarting)
        {
            StartScene();
        }
    }

    private void FadeToClear()
    {
        backImage.color = Color.Lerp(backImage.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    private void FadeToBlack()
    {
        backImage.color = Color.Lerp(backImage.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    private void StartScene()
    {
        backImage.enabled = true;
        FadeToClear();
        if (backImage.color.a <= 0.05f)
        {
            backImage.color = Color.clear;
            backImage.enabled = false;
            sceneStarting = false;
        }
    }

    public void EndScene()
    {
        backImage.enabled = true;
        FadeToBlack();
        if (backImage.color.a >= 0.95f)
        {
            SceneManager.LoadScene("另一个场景");
        }
    }
}
