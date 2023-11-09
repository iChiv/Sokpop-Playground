using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private SpitController spitController;

    private void Start()
    {
        spitController = GetComponent<SpitController>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Alpaca"))
        {
            Debug.Log("hao");
            //UI ºÈË®
            spitController.isDrink = true;
        }

           
    }

}
