using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTwoMovement : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    public float healthCount;

    private Rigidbody2D rb;

    private bool push;

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
        push = GetComponent<Push>().isPushing;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        else if(!push)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        

        if(Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            rb.velocity = new Vector2(0, jumpHeight);
        }

        if(healthCount <= 0)
        {
            // SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
            //Debug.Log("Lost all health");
        }
    }
}
