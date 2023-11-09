using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private SpitController spitController;
    private GameObject _alpcaSpitPonint;

    private void Start()
    {
        
        _alpcaSpitPonint = GameObject.Find("SpitPoint");
        spitController = _alpcaSpitPonint.GetComponent<SpitController>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("hao");
            //UI
            spitController.isDrink = true;
            spitController.spitTime += 5;
        }
    }

}
