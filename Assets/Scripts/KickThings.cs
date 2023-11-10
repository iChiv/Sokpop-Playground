using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Serialization;

public class KickThings : MonoBehaviour
{
    public GameObject pressE;
    public GameObject player;
    public GameObject target;
    public GameObject alpaca;
    
    public float kickForce;
    private bool _kickReady;
    
    public CinemachineImpulseSource ImpulseSource;
    public AudioClip kickSound;
    public AudioSource alpacaAudioSource;
    public ParticleSystem kickVFX;

    private void Start()
    {
        _kickReady = false;
    }

    private void Update()
    {
        if (_kickReady & Input.GetKeyDown(KeyCode.E))
        {
            target.gameObject.GetComponent<Rigidbody>().AddForce((-player.transform.forward+player.transform.up) * kickForce, ForceMode.Impulse);
            if (target.GetComponent<Bouns>() != null)
            {
                alpaca.GetComponent<DestoryBouns>().cucurbitHit += 1;
            }
            kickVFX.Play();
            ImpulseSource.GenerateImpulse();
            alpacaAudioSource.PlayOneShot(kickSound);
        }
    }

    private void OnTriggerStay(Collider other)
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
