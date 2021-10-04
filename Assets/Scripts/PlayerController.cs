using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private float moveInput;

    private bool isGrounded;
    [SerializeField] private Transform characterPos;
    [SerializeField] private float checkRedius;
    [SerializeField] private LayerMask groundTexture;

    private float jumpTimeCounter;
    [SerializeField] private float jumpTime;
    private bool isJumping;
    
    
    private bool allowHorizontalInput = true;
    
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite standing;
    [SerializeField] private Sprite crouching;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

      

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = standing;



    }

    private void FixedUpdate()
    {
        if (allowHorizontalInput)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

            if (rb.position.y < -6f)
            {
                FindObjectOfType<GameManagerScript>().GameOver();
            }
        }
        
        
    }

    private void Update()
    {

        isGrounded = Physics2D.OverlapCircle(characterPos.position, checkRedius, groundTexture);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            
            spriteRenderer.sprite = crouching;


            SoundManagerScript.PlaySound("jump");
            
        } else if (Input.GetKeyUp(KeyCode.W))
        {
            spriteRenderer.sprite = standing;
        }

        {
            
        } 

        if (Input.GetKey(KeyCode.W) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
                
                spriteRenderer.sprite = crouching;
                if (Input.GetKey(KeyCode.D))
                    moveInput = 0.5f;
                else if (Input.GetKey(KeyCode.A))
                    moveInput = -0.5f;
                else
                    moveInput = 0;
                
            }
            else
            {
                isJumping = false;
                spriteRenderer.sprite = standing;
            }

        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }
        
        
        
    }
    

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (jumpTimeCounter > 0 && other.gameObject.tag == "Walls")
        {
            StartCoroutine(LockHorizontalInput(0.5f));
            rb.velocity = Vector3.zero;
            rb.AddForce(other.contacts[0].normal * 5, ForceMode2D.Impulse);
        }

        if (other.gameObject.CompareTag("Snake"))
        {
            SoundManagerScript.PlaySound("playerDie");
            FindObjectOfType<GameManagerScript>().GameOver();
        }
        
        if (other.gameObject.CompareTag("Slime"))
        {
            SoundManagerScript.PlaySound("playerDie");
            FindObjectOfType<GameManagerScript>().GameOver();
        }
    }
    
    
    private IEnumerator LockHorizontalInput(float duration)
    {   
        moveInput = 0;
        allowHorizontalInput = false;
        yield return new WaitForSeconds(0.5f);
        allowHorizontalInput = true;
    }
    
    
}


  
    
    

