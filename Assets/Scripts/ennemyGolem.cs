using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemyGolem : enemy
{
    public Transform checkCollision;
    public float Speed, rad, attackDuration, WalkDuration;
    public Vector3 dir;
    public bool attacking = false;
    float currentSpeed;
    bool flip = false;
    public Vector2 size;
    public LayerMask WhatCanCollide;


    // Start is called before the first frame update
    void Start()
    {

        dir = checkCollision.right;
        currentSpeed = Speed;
        StartCoroutine(CanAttack());
    }

    // Update is called once per frame
    void Update()
    {

        if (Life <= 0)
        {
            Destroy(gameObject);
        }

        if (!attacking)
        {
            transform.position += new Vector3(currentSpeed * Time.deltaTime, 0);
            flip = Physics2D.OverlapBox(checkCollision.position, size, rad, WhatCanCollide);
            if (flip)
            {
                Flip();
            }
        }
        else if (attacking)
        {

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



    IEnumerator CanAttack()
    {
        yield return new WaitForSeconds(WalkDuration);
        attacking = true;
        yield return new WaitForSeconds(attackDuration);
        attacking = false;
    

        StartCoroutine(CanAttack());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(checkCollision.position, size);
    }
}
