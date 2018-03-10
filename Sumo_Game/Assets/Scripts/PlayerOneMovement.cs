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

    private Attack attackScript;
   


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        attackScript = GetComponent<Attack>();
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
        }
        
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        if (attackScript.isBlocking)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }


        if (healthCount <= 0)
        {
            //  SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
           // Debug.Log("Lost all health");
        }

    }
}
