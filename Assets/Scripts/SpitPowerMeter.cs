using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpitPowerMeter : MonoBehaviour
{
    public float spitPowerPoints = 100f;

    public float spitPowerMeter;
    public Image spitImage;

    private SpitController spitController;
    private GameObject _alpcaSpitPonint;

    private void Start()
    {
        _alpcaSpitPonint = GameObject.Find("SpitPoint");
        spitController = _alpcaSpitPonint.GetComponent<SpitController>();
    }
    void Update()
    {
        spitPowerMeter = Mathf.Floor(spitController.spitTime);
        spitImage.fillAmount = spitPowerMeter / spitPowerPoints;
    }
}
