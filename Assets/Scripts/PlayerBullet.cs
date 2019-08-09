using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : TimeController
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Move()
    {
        gameObject.transform.Translate(Vector2.right * Speed * Time.deltaTime * TimeFactor);
    }
    public void CheckVisibility()
    {
        if (transform.position.x > Camera.main.transform.position.x + Camera.main.orthographicSize + 2f || transform.position.x < Camera.main.transform.position.x - Camera.main.orthographicSize - 2f)
        {
            Destroy(gameObject);
        }
    }
}
