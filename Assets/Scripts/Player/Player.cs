using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myrigidbody2d;

    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float forcejump = 2;
    public HealthBase healthBase;   

    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string boolRun = "Run";
    public string triggerDeath = "Death";
    public Animator animator;
    public float playerSwipeDuration = .1f;

    private float _currentSpeed;
    private Vector3 originalScale;


    private void Awake()
    {
        if(healthBase !=null)
        {
            healthBase.OnKill += OnPlayerKill;
        }
    }

    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
            animator.SetTrigger(triggerDeath);
    }

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun;
            animator.speed = 2;
        }
        else
        {
            _currentSpeed = speed;
            animator.speed = 1;
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0)
        {
            animator.SetBool(boolRun, true);
            myrigidbody2d.velocity = new Vector2(horizontalInput * _currentSpeed, myrigidbody2d.velocity.y);

            if (myrigidbody2d.velocity.x > 0 && transform.localScale.x < 0)
            {
                Flip();
            }
            else if (myrigidbody2d.velocity.x < 0 && transform.localScale.x > 0)
            {
                Flip();
            }
        }
        else
        {
            animator.SetBool(boolRun, false);
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

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2d.velocity = Vector2.up * forcejump;
            DOTween.Kill(transform);
            // Não faz nada com a escala do transform durante o pulo
        }
    }

    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public void Destroyme()
    {
        Destroy(gameObject);
    }
}
