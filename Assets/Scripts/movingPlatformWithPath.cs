using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatformWithPath : MonoBehaviour
{
    public float Speed;
    public Transform[] checkPoints;
    int nextPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, checkPoints[nextPoint].position, Speed * Time.deltaTime);

        if(transform.position.x == checkPoints[nextPoint].position.x && transform.position.y == checkPoints[nextPoint].position.y)
        {
            GoToNextPoint();
        }
    }

    void GoToNextPoint()
    {
        nextPoint++;
        if(nextPoint >= checkPoints.Length)
        {
           
            nextPoint = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.parent = this.gameObject.transform;
        }
      
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.parent = null;

        }
    }
}
