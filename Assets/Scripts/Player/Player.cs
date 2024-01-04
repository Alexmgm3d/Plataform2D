using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public Rigidbody2D myrigidbody2d;
    //public Vector2 velocity;
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float forcejump = 2;
    private float _currentSpeed;
    

    private void Update()
    {
        Handlejump();
        Handlemoviment();
        
    }

       
        private void Handlemoviment()
        {
        if (Input.GetKey(KeyCode.LeftShift))
            _currentSpeed = speedRun;

        else
            _currentSpeed = speed;



            if (Input.GetKey(KeyCode.RightArrow))
            {
                //Movimentação do personagem - myrigidbody2d.MovePosition(myrigidbody2d.position + velocity * Time.deltaTime);
                myrigidbody2d.velocity = new Vector2(_currentSpeed, myrigidbody2d.velocity.y);
            }

            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                // movimentação do personagem - myrigidbody2d.MovePosition(myrigidbody2d.position - velocity * Time.deltaTime);
                myrigidbody2d.velocity = new Vector2(-_currentSpeed, myrigidbody2d.velocity.y);

            }

            if (myrigidbody2d.velocity.x > 0)
        {
                myrigidbody2d.velocity += friction;
        }

            else if (myrigidbody2d.velocity.x <0)
        {
            myrigidbody2d.velocity -= friction;
        }

    }

    private void Handlejump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2d.velocity = Vector2.up * forcejump; 
        }

    }
}


