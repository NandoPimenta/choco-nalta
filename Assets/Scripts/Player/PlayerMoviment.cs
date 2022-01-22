using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    public Rigidbody2D myRigidbody2D;

    public Vector2 velocity = new Vector2(10f,0f);

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)){
            //myRigidbody2D.MovePosition(myRigidbody2D.position - velocity * Time.deltaTime);
            myRigidbody2D.velocity = new Vector2(-speed, myRigidbody2D.velocity.y);
        }else if(Input.GetKey(KeyCode.RightArrow)){
            myRigidbody2D.velocity = new Vector2(speed, myRigidbody2D.velocity.y);
        }
    }
}
