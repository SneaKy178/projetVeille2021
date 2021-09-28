using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDelimiterScript : MonoBehaviour
{
    [SerializeField] private Transform rayCast;
    private Camera camera;
    private bool playerHit = false;

    private void Awake()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayCast.transform.position, Vector2.left * 150f);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player") && !playerHit)
            {
                Debug.Log("hit the player");
                playerHit = true;

            }

            if (playerHit)
            {
                playerHit = false;
                //camera.transform.Translate(0.5f,0,0);
            }
            
        }
        else
        {
            Debug.Log("Nothing hit");
        }
    }
}
