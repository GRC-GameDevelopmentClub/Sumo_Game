using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOneMovement : MonoBehaviour {


    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private Rigidbody2D rb;

    public float healthCount;

    private bool facingRight;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update () {
		
        if(Input.GetKey (KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            rb.transform.localScale = new Vector2(-1, 1);
        }
        
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            rb.transform.localScale = new Vector2(1, 1);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            rb.velocity = new Vector2(0, jumpHeight);
        }

        if (healthCount <= 0)
        {
            //  SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
            Debug.Log("Lost all health");
        }

    }

  
}
