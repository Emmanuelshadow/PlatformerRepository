using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformEnemy : enemy
{
    public Transform checkGround;
    public float Speed, rayDistance;
    bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Life <= 0)
        {
            Destroy(gameObject);
        }
            grounded = Physics2D.Raycast(checkGround.position, Vector2.down, rayDistance );

            if (grounded)
            {
                transform.position += new Vector3(Speed * Time.deltaTime * TimeFactor, 0);
            }
            else
            {
                Flip();
            }

    }

    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        Speed *= -1;
    }
}
