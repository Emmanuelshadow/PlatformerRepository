using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : TimeController
{
    public float speed, rayDistance;
    public Transform rayStart;
    Vector3 rayDir;

    private void Start()
    {
        rayDir = rayStart.right;
    }
    private void Update()
    {


        transform.position += new Vector3(speed * Time.deltaTime * TimeFactor, 0);



        RaycastHit2D r1 = Physics2D.Raycast(rayStart.position, rayDir, rayDistance * TimeFactor);
        CheckCollision(r1);
    }
    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        rayDir *= -1;
    }

    void CheckCollision(RaycastHit2D ray)
    {
        if(ray.collider != null &&  ray.collider.name != name)
        {
            Flip();
        }
    }
}
