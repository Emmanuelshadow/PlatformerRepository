using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideScrolling : MonoBehaviour
{
    public  float Speed, currentSpeed;
    private Renderer Rend;
    Vector2 camPos;
    float dir = 0;
    // Start is called before the first frame update
    void Start()
    {
        Rend = GetComponent<Renderer>();
        camPos = GameObject.FindGameObjectWithTag("MainCamera").gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(GameObject.FindGameObjectWithTag("MainCamera").gameObject.transform.position.x != camPos.x)
        {
            dir = GameObject.FindGameObjectWithTag("MainCamera").gameObject.transform.position.x - camPos.x;
            camPos = GameObject.FindGameObjectWithTag("MainCamera").gameObject.transform.position;
        }
        currentSpeed = Speed * dir;
        Rend.material.SetTextureOffset("_MainTex", new Vector2(Rend.material.mainTextureOffset.x + currentSpeed * Time.deltaTime, 0));
    }
}
