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
    private BoxCollider2D box;
    private bool directRight = true;
    private bool canJump = true, wasGrounded = false;
    private float horizontalInput;

    private Rigidbody2D rb;
    private Animator anim;

    public LayerMask groundLayer;
    public LayerMask enemyLayer;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
       
    }

    void Update()
    {
        checkGround();

        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded && canJump)
        {
            rb.linearVelocityY = jumpForce;
            canJump = false;
            Invoke(nameof(ResetJump), 0.2f);

            Sound.instance.PlayClip(Sound.instance.jump, transform.position);
        }

        flipControl();

        if (horizontalInput!=0 && isGrounded)
        {
            if (!Sound.instance.walking.isPlaying)
            Sound.instance.StartWalking(transform.position, 0.3f);
        }
        else Sound.instance.StopWalking();

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
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, box.size.y/2, groundLayer | enemyLayer);
        if (isGrounded && !wasGrounded)
        {
            Sound.instance.PlayClip(Sound.instance.land, transform.position);
        }
        wasGrounded = isGrounded;
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
    void ResetJump()
    {
        canJump = true;
    }
}