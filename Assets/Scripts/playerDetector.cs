using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDetector : MonoBehaviour
{
    public GameObject Owner;
    public Vector2 Force = new Vector2(0, 250);
    // Start is called before the first frame update
    void Start()
    {
        Owner = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Player>().TakeDamage(Owner.GetComponent<enemy>().damage);
            if(col.gameObject.transform.position.x > Owner.transform.position.x)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Force);
            }
            else if (col.gameObject.transform.position.x < Owner.transform.position.x)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-Force.x, Force.y));
            }

        }
    }

}
