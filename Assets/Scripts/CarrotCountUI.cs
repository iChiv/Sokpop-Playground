using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarrotCountUI : MonoBehaviour
{
    public GameObject alpaca;
    public int carrotNumber;

    public TextMeshProUGUI carrotUI;

    // Update is called once per frame
    void Update()
    {
        carrotNumber = alpaca.GetComponent<CarrotCount>().carrotCatched;
        carrotUI.text = "You got "+carrotNumber.ToString() + " carrots in total, awesome!";
    }
}
