using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public Rigidbody2D myrigidbody2d;
    public Vector2 velocity;
    public float speed;

    private void Update()
    {
    
       
        if(Input.GetKey(KeyCode.RightArrow))
        {
            //Movimentação do personagem - myrigidbody2d.MovePosition(myrigidbody2d.position + velocity * Time.deltaTime);
            myrigidbody2d.velocity = new Vector2(speed, myrigidbody2d.velocity.y);
        }

        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            // movimentação do personagem - myrigidbody2d.MovePosition(myrigidbody2d.position - velocity * Time.deltaTime);
            myrigidbody2d.velocity = new Vector2(-speed, myrigidbody2d.velocity.y);
        }
    }
}
