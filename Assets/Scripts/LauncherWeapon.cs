using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherWeapon : MonoBehaviour
{
    public float cadence;
     float dir;
    public Vector2 Force;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
      


        InvokeRepeating("Shoot", cadence, cadence);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Shoot()
    {
        dir = transform.parent.transform.localScale.x * -1;
        GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
            b.GetComponent<Rigidbody2D>().AddForce(new Vector2(Force.x * dir, Force.y));


    }
}
