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

    private float _currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
        else
        {
            _currentSpeed = speed;
        }


        if (Input.GetKey(KeyCode.A))
        {
            //myRigidbody2D.MovePosition(myRigidbody2D.position - velocity * Time.deltaTime);
            myRigidbody2D.velocity = new Vector2(-_currentSpeed, myRigidbody2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myRigidbody2D.velocity = new Vector2(_currentSpeed, myRigidbody2D.velocity.y);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody2D.velocity = Vector2.up * forceJump;
            myRigidbody2D.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody2D.transform);
            HandleScaleJump();
        }
    }


    private void HandleScaleJump()
    {
        myRigidbody2D.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(ease);
        myRigidbody2D.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

}
