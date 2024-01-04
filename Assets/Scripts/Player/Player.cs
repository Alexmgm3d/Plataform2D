using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{


    public Rigidbody2D myrigidbody2d;
    //public Vector2 velocity;
    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float forcejump = 2;

    [Header("Animation Setup")]
    private float jumpScaleY = 1.5f;
    private float jumpScaleX = 0.7f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;

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

        else if (myrigidbody2d.velocity.x < 0)
        {
            myrigidbody2d.velocity -= friction;
        }

    }

    private void Handlejump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2d.velocity = Vector2.up * forcejump;
            myrigidbody2d.transform.localScale = Vector2.one;
            DOTween.Kill(myrigidbody2d.transform);

            HandleScaleJump();

        }
    }



    private void HandleScaleJump()
    {
        myrigidbody2d.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myrigidbody2d.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

}
