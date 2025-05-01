using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Rendering;

public class JoyStick : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float speed = 8;
    private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    private bool directRight = true;
    private float horizontalInput;

    private Rigidbody2D rb;
    private Animator anim;

    public LayerMask groundLayer;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        groundLayer = LayerMask.GetMask("Ground");
    }

    void Start()
    {
       
    }

    void Update()
    {
        checkGround();

        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        flipControl();

        anim.SetBool("isRunning", horizontalInput!=0);
        anim.SetBool("isJumping", !isGrounded);
        anim.SetFloat("yVelocity", rb.linearVelocityY);
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }

    private void checkGround()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
    }

    private void flipControl()
    {
        if (horizontalInput > 0.01f)
        {
            if (!directRight)
            {
                Vector3 localScale = transform.localScale;
                localScale.x *= -1;
                transform.localScale = localScale;

                directRight = true;
            }
        }
        else if (horizontalInput < -0.01f) 
        {
            if (directRight)
            {
                Vector3 localScale = transform.localScale;
                localScale.x *= -1;
                transform.localScale = localScale;

                directRight = false;
            }
        }
    }
}