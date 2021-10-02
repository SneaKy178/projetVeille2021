using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireballScript : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float speed = 20;
    [SerializeField] private float lifeTime = 10f;

     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition( transform.TransformPoint(Vector3.right * speed * Time.deltaTime));
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManagerScript>().GameOver();
        }
    }
    

}
