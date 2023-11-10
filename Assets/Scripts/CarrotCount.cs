using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarrotCount : MonoBehaviour
{
    public int carrotCatched;
    public TextMeshProUGUI carrotCountDisplay;

    private void Awake()
    {
        carrotCatched = 0;
    }

    private void Update()
    {
        carrotCountDisplay.text =  carrotCatched.ToString();
    }
}
