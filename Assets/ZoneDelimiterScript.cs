using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDelimiterScript : MonoBehaviour
{
    [SerializeField] private Transform rayCast;

    
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayCast.transform.position, Vector2.left * 150f);
        if (hit.collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("touche le joueur");
        }
    }
}
