using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTarget : MonoBehaviour
{
    public float scrollSpeed = 8;

    private GameObject player;
    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // camera follow player
        transform.position = player.transform.position - offset;

        //mouse change fielview
        float scroll = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        Camera.main.fieldOfView += scroll;

        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 30, 70);
        

    }
}
