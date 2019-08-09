using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{

    public float Speed, ampli, frequence;
    Vector2 pos;
    

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Speed * Time.deltaTime, 0);

        transform.position = new Vector2(transform.position.x, pos.y + Mathf.Sin(Time.time) * ampli);        
        
    }
}
