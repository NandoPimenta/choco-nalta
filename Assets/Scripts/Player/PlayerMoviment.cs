using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMoviment : MonoBehaviour
{

    [Header("Setup")]
    public SOPlayerSetup sOPlayerSetup;


    public Rigidbody2D myRigidbody2D;
    public HealthBase healthBase;
    public Animator animator;
    public ParticleSystem particleDust;
    public ParticleSystem particleJump;
    
    private string boolRun = "Run";
    private string boolJumpUp = "JumpUp";
    private string boolJumpDown = "JumpDown";
    private string triggerDeath = "Death";

    private float playerSwipeDuration = .1f;
    private bool isJumping = false;
    private float _currentSpeed;
    
        

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }
    }

    private void OnPlayerKill()
    {
        
        healthBase.OnKill -= OnPlayerKill;
        animator.SetTrigger(triggerDeath);
    }


    // Update is called once per frame
    void Update()
    {
        HandleJump();
        HandleMoviment();
    }



    private void HandleMoviment()
    {



        if (Input.GetKey(KeyCode.LeftControl))
        {
                
            _currentSpeed = sOPlayerSetup.speedRun;
            animator.speed = 2;
            
        }
        else
        {
            _currentSpeed = sOPlayerSetup.speed;
            animator.speed = 1;

        }


        if (Input.GetKey(KeyCode.A))
        {
            if(particleDust.isStopped) particleDust.Play();
            myRigidbody2D.velocity = new Vector2(-_currentSpeed, myRigidbody2D.velocity.y);
            if(myRigidbody2D.transform.localScale.x != -1)
            {
                myRigidbody2D.transform.DOScaleX(-1, playerSwipeDuration);
            }
                
            animator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if(particleDust.isStopped) particleDust.Play();
            myRigidbody2D.velocity = new Vector2(_currentSpeed, myRigidbody2D.velocity.y);
            if (myRigidbody2D.transform.localScale.x != 1)
            {
                myRigidbody2D.transform.DOScaleX(1, playerSwipeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else
        {
            animator.SetBool(boolRun, false);
        }


        if(myRigidbody2D.velocity.x > 0)
        {
            myRigidbody2D.velocity += sOPlayerSetup.friction; 
        }else if (myRigidbody2D.velocity.x < 0)
        {
            myRigidbody2D.velocity -= sOPlayerSetup.friction;
        }

    }


    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {   
            particleDust.Stop();
            particleJump.Play();
            isJumping = true;
            animator.SetBool(boolJumpUp, true);
            myRigidbody2D.velocity = Vector2.up * sOPlayerSetup.forceJump;
            myRigidbody2D.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody2D.transform);
            
            StartCoroutine(JumpDown());
          
        }
    }


    IEnumerator JumpDown()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool(boolJumpUp, false);
        animator.SetBool(boolJumpDown, true);
        


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        if (collision.gameObject.CompareTag("floor"))
        {
            animator.SetBool(boolJumpUp, false);
            animator.SetBool(boolJumpDown, false);
            isJumping = false;
        }
    }


    public void DestroyMe()
    {
        Destroy(gameObject);
    }

}
