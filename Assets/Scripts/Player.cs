using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 3f; 
    private Rigidbody2D rb;
    [SerializeField] private AudioSource jumpSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            jumpSound.Play();
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce; 
    }

    private void OnTriggerEnter2D(Collider2D other){
    
        if (other.gameObject.CompareTag("Dead")){
            Destroy(gameObject);
        }
    }
}