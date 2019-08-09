using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWeapon : MonoBehaviour
{
    public GameObject bullet;
    public float Cadence, dir;
    

    private void Start()
    {
        InvokeRepeating("Shoot", Cadence, Cadence);
    }

    void Shoot()
    {
       GameObject b =  Instantiate(bullet, transform.position, Quaternion.identity);
        b.GetComponent<bullet>().speed *= dir;
    }
}
