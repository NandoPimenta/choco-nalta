using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMoviment : MonoBehaviour
{

    public Rigidbody2D myRigidbody2D;


    [Header("Speed setup")]
    public Vector2 friction = new Vector2(-.1f, 0);
    public float speed = 5f;
    public float speedRun = 10f;
    public float forceJump = 7f;

    [Header("Animation setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = .7f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;
    public HealthBase healthBase;

    private float _currentSpeed;


    [Header("Animation player")]
    public string boolRun = "Run";
    public string boolJumpUp = "JumpUp";
    public string boolJumpDown = "JumpDown";
    public string triggerDeath = "Death";
    public Animator animator;
    private float playerSwipeDuration = .1f;
    private bool isJumping = false;


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
                
            _currentSpeed = speedRun;
            animator.speed = 2;
            
        }
        else
        {
            _currentSpeed = speed;
            animator.speed = 1;

        }


        if (Input.GetKey(KeyCode.A))
        {
            
            myRigidbody2D.velocity = new Vector2(-_currentSpeed, myRigidbody2D.velocity.y);
            if(myRigidbody2D.transform.localScale.x != -1)
            {
                myRigidbody2D.transform.DOScaleX(-1, playerSwipeDuration);
            }
                
            animator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
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
            myRigidbody2D.velocity += friction; 
        }else if (myRigidbody2D.velocity.x < 0)
        {
            myRigidbody2D.velocity -= friction;
        }

    }


    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            animator.SetBool(boolJumpUp, true);
            myRigidbody2D.velocity = Vector2.up * forceJump;
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
