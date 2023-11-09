using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public float drinkSpeed;
    private SpitController spitController;
    private GameObject _alpcaSpitPonint;

    private void Start()
    {
        
        _alpcaSpitPonint = GameObject.Find("SpitPoint");
        spitController = _alpcaSpitPonint.GetComponent<SpitController>();
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //UI
            spitController.isDrink = true;
            spitController.spitTime += drinkSpeed * Time.deltaTime;
        }
    }

}
