using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float Speed = 0, decelerationSpeed, accelerationSpeed, MaxSpeed, JumpForce, moveInput, coolDownDuration, ComboTime, gravityMutiplicater, rad, TimeEffectDuration, TimeModifier;
    public bool grounded, attackFinished, isCoolDown = false, canMove = true, running;
    public Transform groundCkeck, attackPos;
    public Rigidbody2D rb;
    public GameObject[] skills;
    float  LastTime;
    public int attackIndex = 0;
    public LayerMask groundLayer;
    public float Horizontal;
    int dir = 1;
    float DefaultGravityScale, startScale;
    private Animator anim;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        DefaultGravityScale = rb.gravityScale;
        startScale = transform.localScale.x;
    }

    // Update is called once per frame
    private void Update()
    {
        running = Speed != 0;
        anim.SetBool("Running", running);
        grounded = Physics2D.OverlapCircle(groundCkeck.position, rad, groundLayer);
      


    }
    private void FixedUpdate()
    {
        rb.gravityScale = DefaultGravityScale * gravityMutiplicater;

        if (Input.GetAxis("Horizontal") < 0 )
        {
            Vector3 scaler = transform.localScale;
            scaler.x = -startScale;
            transform.localScale = scaler;
            dir = -1;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            Vector3 scaler = transform.localScale;
            scaler.x = startScale;
            transform.localScale = scaler;

            dir = 1;
        }
        if(Input.GetAxis("Horizontal") != 0 && Speed < MaxSpeed )
        {
            Speed += accelerationSpeed * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") == 0 && Speed > 0 )
        {
            Speed -= decelerationSpeed * Time.deltaTime;
        }
        if (Speed < 0)
        {
            Speed = 0;
        } 
       Horizontal =  dir * Speed;



        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(BlockTime());
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {

            rb.velocity = new Vector2(rb.velocity.x, JumpForce * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        rb.velocity =  new Vector2(Horizontal, rb.velocity.y);

    }


    void Attack()
    {

        if (isCoolDown){return;}

     
            GameObject b = Instantiate(skills[attackIndex], attackPos.position,Quaternion.identity);
        if(transform.localScale.x < 0)
        {
            b.GetComponent<PlayerBullet>().Speed *= -1;
        }
        
            StopAllCoroutines();
            StartCoroutine(CoolDown());
        
     


    }

    IEnumerator CoolDown()
    {
        isCoolDown = true;
        yield return new WaitForSeconds(coolDownDuration);
        isCoolDown = false;
        attackIndex++;
        if(attackIndex >= skills.Length)
        {
            attackIndex = 0;
        }

        yield return new WaitForSeconds(ComboTime);
        attackIndex = 0;

    }

    public void TakeDamage(int dam)
    {

    }

    IEnumerator BlockTime()
    {
        TimeController[] elementsPresent = GameObject.FindObjectsOfType<TimeController>();

        for(int i = 0; i < elementsPresent.Length; i++)
        {
            elementsPresent[i].TimeFactor = TimeModifier;
        }

        yield return new WaitForSeconds(TimeEffectDuration);

        for (int i = 0; i < elementsPresent.Length; i++)
        {
            elementsPresent[i].TimeFactor = 1;
        }

    }
    IEnumerator SlowDownTime()
    {
        TimeController[] elementsPresent = GameObject.FindObjectsOfType<TimeController>();

        for(int i = 0; i < elementsPresent.Length; i++)
        {
            elementsPresent[i].TimeFactor = 0.2f;
        }

        yield return new WaitForSeconds(TimeEffectDuration);

        for (int i = 0; i < elementsPresent.Length; i++)
        {
            elementsPresent[i].TimeFactor = 1;
        }

    }
}
