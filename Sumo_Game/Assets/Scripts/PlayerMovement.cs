﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private Rigidbody2D rb;
    public float healthCount;

    private Attack attackScript;

    private Color defaultColor;
    public Color deathColor;

    public float maxHealth;
    private SpriteRenderer sr;


    public KeyCode left, right, jump;
    public string name;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        attackScript = GetComponent<Attack>();
        defaultColor = GetComponentInChildren<SpriteRenderer>().color;
        maxHealth = healthCount;
        sr = GetComponentInChildren<SpriteRenderer>();

    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    float colorTimer;
    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        else if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else if (sr.color == defaultColor) 
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(jump) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        if (attackScript.isBlocking)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (sr.color != defaultColor)
        {
            colorTimer += Time.deltaTime;
            if (colorTimer > 0.25f)
            {
                sr.color = defaultColor;
                colorTimer = 0;
            }
        }

        if (healthCount <= 0)
        {
            SceneManager.LoadScene("Lose");
        }

        flipScale();
    }

    public void flipScale()
    {
        if (rb.velocity.x < 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (rb.velocity.x > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
