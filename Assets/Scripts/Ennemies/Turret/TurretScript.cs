using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] private float scanRadius = 5f;
    [SerializeField] private LayerMask layers;
    private Collider2D target;

    [SerializeField] private GameObject fireball;
    [SerializeField] private Transform firepoint;
    [SerializeField] private float fireDelay = 2f;


    private void Start()
    {
        InvokeRepeating("Fire", 0f, fireDelay);
    }

    private void Update()
    {
        CheckEnvironment();
    }

    private void CheckEnvironment()
    {
        target = Physics2D.OverlapCircle(transform.position, scanRadius, layers);
        LookAtTarget();
    }

    private void LookAtTarget()
    {
        if (target != null)
        {
            Vector2 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void Fire()
    {
        if (target != null)
        {
            Instantiate(fireball, firepoint.position,firepoint.rotation);
            SoundManagerScript.PlaySound("shooting");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, scanRadius);
    }
    
    
}
