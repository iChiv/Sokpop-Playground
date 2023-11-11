using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotCatchByPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject alpaca;
    
    [Header("Catch Function")]
    public float speed;
    public float catchRange;
    
    [Header("vFX")]
    public ParticleSystem success;
    
    [Header("VFX")]
    public AudioClip carrotCatchedSFX;
    public AudioSource carrotSoundSource;

    private bool _catched = false;
    
    private void Awake()
    {
        player = GameObject.Find("PlayerCapsule");
        alpaca = GameObject.Find("Alpaca");
        carrotSoundSource = alpaca.GetComponent<AudioSource>();
        success = GameObject.Find("Success Particles").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform playerTransform = player.transform;
        var distance = Vector3.Distance(transform.position, playerTransform.position);
        float step = speed * Time.deltaTime;

        if (distance <= catchRange)
        {
            gameObject.transform.localPosition=new Vector3(
                Mathf.Lerp(gameObject.transform.localPosition.x, playerTransform.position.x, step),
                Mathf.Lerp(gameObject.transform.localPosition.y, playerTransform.position.y, step),
                Mathf.Lerp(gameObject.transform.localPosition.z, playerTransform.position.z, step));
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!_catched)
            {
                alpaca.GetComponent<CarrotCount>().carrotCatched += 1;
                _catched = true;
            }
            //SFX
            carrotSoundSource.clip = carrotCatchedSFX;
            carrotSoundSource.Play();
            success.Play();
            Destroy(this.gameObject);
        }
    }
}
