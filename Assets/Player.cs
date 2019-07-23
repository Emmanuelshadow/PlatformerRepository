using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed, JumpForce;
    public bool grounded;
    public Transform groundCkeck;
    public Rigidbody2D rb;
    float moveInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        grounded = Physics2D.OverlapPoint(groundCkeck.position);
    }
    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * Speed * Time.fixedDeltaTime, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = Vector2.up * JumpForce * Time.deltaTime;
        }
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
    }
}
