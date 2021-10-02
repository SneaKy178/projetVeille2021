using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDelimiterScript : MonoBehaviour
{
    [SerializeField] private Transform rayCast;
    private Camera camera;
    private bool playerHit = false;
    private bool fireRaycast = true;

    private void Awake()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayCast.transform.position, Vector2.up * 150f);
        if (hit.collider != null && fireRaycast)
        {
            if (hit.collider.gameObject.CompareTag("Player") && !playerHit && fireRaycast)
            {
                playerHit = true;
                fireRaycast = false;
            }
            
            if (playerHit && gameObject.tag == "Zone1")
            {
                camera.transform.Translate(11,0,0);
            }
            else if (playerHit && gameObject.tag == "Zone2")
            {
                camera.transform.Translate(3,0,0);
            }
            else if (playerHit && gameObject.tag == "Zone3")
            {
                camera.transform.Translate(-12,6,0);
            }
            else if (playerHit && gameObject.tag == "Zone4")
            {
                camera.transform.Translate(-5,0,0);
            }

           
            
        }
    }
}
