using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotativeBullet : MonoBehaviour
{
    public float rotateSpeed, life;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed));
        Destroy(gameObject, life);
    }
}
