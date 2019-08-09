using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : TimeController
{
    public float Life;
    public int damage;

    

    // Update is called once per frame
    void Update()
    {

        if(Life <= 0)
        {

            Destroy(gameObject);
        }
    }
    public void TakeDamage(int d)
    {
        Life -= d;
    }

   
}
