using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Rendering;

public class JoyStick : MonoBehaviour
{
    public float jumpForce = 10f;
    public float radius;
    // public CharacterController2d controller2D;
    [SerializeField] private float speed = 8;

    private Rigidbody2D rb;
    public Transform groundPos;
    private bool isGrounded;
    public LayerMask WhatIsGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform ceilingCheck;
    // private float jumpTimeCounter;

    // public GameObject attackPoint;
// public Transform attackPoint = parentTransform.Find("attackPoint");
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float jumpTime;
    private Animator anim;
    private float horizontalInput;
    [SerializeField] private int jumpAmount = 10;
    private bool isRightFacing = true;
    public float gravityScale = 5;
    public LayerMask enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }

      

        anim.SetBool("isRunning", horizontalInput!=0);
        anim.SetBool("isGrounded", isGrounded);
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.linearVelocity.y);
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
        if (horizontalInput > 0)
        {
            Debug.Log("right");
            isRightFacing = true;
            transform.localScale = 3*Vector2.one;
        }
        else if (horizontalInput < 0) 
        {
            Debug.Log("left");
            isRightFacing = false;
            transform.localScale = new Vector2(-3, 3);
        }
        else 
        {
            if (isRightFacing) 
                transform.localScale = 3*Vector2.one;
            else             
                transform.localScale = new Vector2(-3, 3);

        }
    }
    private void OnCollisionEnter2D(Collision2D others)
    {
        if (others.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("isGrounded", true);
            Debug.Log ("not jump");
        }
    }

    private void OnCollisionExit2D(Collision2D others)
    {
        if (others.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("jump");
        }
    }

}