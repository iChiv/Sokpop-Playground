using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickThings : MonoBehaviour
{
    public GameObject pressE;
    public GameObject player;
    public float kickForce;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CanKick"))
        {
            pressE.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                other.gameObject.GetComponent<Rigidbody>().AddForce(-player.transform.forward * kickForce, ForceMode.Impulse);
                Debug.Log("Kick");
            }
        }
        else
        {
            pressE.SetActive(false);
        }
    }
}
