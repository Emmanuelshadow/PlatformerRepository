using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : TimeController
{
    public float lifeTime, speed;



    private void Update()
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * TimeFactor * Time.deltaTime, 0);

        Destroy(gameObject, lifeTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
