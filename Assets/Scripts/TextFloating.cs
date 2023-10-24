using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFloating : MonoBehaviour
{
    public Transform mainCam;

    public Transform player;

    public Transform worldSpaceCanvas;

    public new Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main.transform;
        player = transform.parent;
        worldSpaceCanvas = GameObject.Find("WorldSpaceCanvas").transform;
        
        transform.SetParent(worldSpaceCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCam.transform.position);
        transform.position = player.position + offset;
    }
}
