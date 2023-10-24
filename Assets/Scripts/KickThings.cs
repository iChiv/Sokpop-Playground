using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickThings : MonoBehaviour
{
    public GameObject pressE;
    public GameObject player;
    public GameObject target;
    public float kickForce;
    private bool _kickReady;

    private void Start()
    {
        _kickReady = false;
    }

    private void Update()
    {
        if (_kickReady & Input.GetKeyDown(KeyCode.E))
        {
            target.gameObject.GetComponent<Rigidbody>().AddForce((-player.transform.forward+player.transform.up) * kickForce, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CanKick"))
        {
            _kickReady = true;
            pressE.SetActive(true);
            target = other.gameObject;
        }
        else
        {
            pressE.SetActive(false);
            _kickReady = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pressE.SetActive(false);
        _kickReady = false;
    }
}
