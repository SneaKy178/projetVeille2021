﻿using System;
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
                Debug.Log("hit the player");
                playerHit = true;
                fireRaycast = false;
            }
            
            if (playerHit)
            {
                camera.transform.Translate(15,0,0);
            }

           
            
        }
        else
        {
            Debug.Log("Nothing hit");
        }
    }
}
