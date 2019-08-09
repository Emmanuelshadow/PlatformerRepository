using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : PlayerBullet
{
    public int damage;
    private Renderer rend;
    float life = 7f;
    public LayerMask timeZone;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        if(Speed < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
        }
    }
    private void Update()
    {
        Move();

        CheckVisibility();
        
       
    }


    public override void Move()
    {
        base.Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            collision.gameObject.GetComponent<enemy>().TakeDamage(damage);
        }
        
        if(collision.gameObject.layer != 13)
        {
            Destroy(gameObject);
        }
       
    }
}
