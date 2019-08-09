using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : enemy
{

    public Transform checkCollision;
    public float Speed, rad;
    public Vector3 dir;
    float currentSpeed;
    bool flip = false;
    public Vector2 size;
    public LayerMask WhatCanCollide;
 

    // Start is called before the first frame update
    void Start()
    {
        
        dir = checkCollision.right;
        currentSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Life<= 0)
        {
            Destroy(gameObject);
        }


        transform.position += new Vector3(currentSpeed * Time.deltaTime * TimeFactor, 0);








        flip = Physics2D.OverlapBox(checkCollision.position, size * TimeFactor, rad, WhatCanCollide );
        if (flip)
        {
            Flip();
        }

        
       
    }

    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        currentSpeed *= -1;
        dir = -dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PlayerEnter");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PlayerExit");
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(checkCollision.position, size);
    }

}
