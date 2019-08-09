using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollower : enemy
{

    public Transform checkGround;
    public float Speed, rayDistance, rayDistance2, maxDistance, minDistance;
    public bool grounded, follow = false;
    public Vector3 dir;
    float currentSpeed;


    void Start()
    {
        dir = checkGround.right;
        currentSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (Life <= 0)
        {
            Destroy(gameObject);
        }
        if (follow == false)
        {
            grounded = Physics2D.Raycast(checkGround.position, Vector2.down, rayDistance * TimeFactor);

            if (grounded)
            {
                transform.position += new Vector3(currentSpeed * Time.deltaTime * TimeFactor, 0);
            }
            else
            {
                Flip();
            }
          
        }


        if (follow)
        {
            if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) > minDistance)
            {
                Vector2 Target = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x, transform.position.y);
                if (Target.x > transform.position.x)
                {
                    if (transform.localScale.x > 0)
                    {
                        Flip();
                    }
                }
                else if (Target.x < transform.position.x)
                {
                    if (transform.localScale.x < 0)
                    {
                        Flip();
                    }

                }
                transform.position = Vector2.MoveTowards(transform.position, Target, Speed * Time.deltaTime * TimeFactor);
            }



        }
        if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) > maxDistance)
        {
            follow = false;
        }


        RaycastHit2D ray = Physics2D.Raycast(checkGround.position, dir, rayDistance2 * TimeFactor);

        if (ray.collider != null && ray.collider.CompareTag("Player"))
        {
            follow = true;
        }

    }

    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        currentSpeed *= -1;
        dir = -dir;
    }

}
