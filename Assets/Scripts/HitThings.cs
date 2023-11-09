using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class HitThings : MonoBehaviour
{
    public GameObject pressE;
    public GameObject player;
    public GameObject target;
    public GameObject alpaca;
    public float hitForce;
    private bool _hitReady;

    public CinemachineImpulseSource ImpulseSource;

    private void Start()
    {
        _hitReady = false;
    }

    private void Update()
    {
        if (_hitReady & Input.GetKeyDown(KeyCode.E))
        {
            target.gameObject.GetComponent<Rigidbody>().AddForce(player.transform.forward * hitForce, ForceMode.Impulse);
            if (target.GetComponent<Bouns>() != null)
            {
                alpaca.GetComponent<DestoryBouns>().chickHit += 1;
            }
            ImpulseSource.GenerateImpulse();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CanHit"))
        {
            _hitReady = true;
            pressE.SetActive(true);
            target = other.gameObject;
        }
        else
        {
            pressE.SetActive(false);
            _hitReady = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pressE.SetActive(false);
        _hitReady = false;
    }
}
