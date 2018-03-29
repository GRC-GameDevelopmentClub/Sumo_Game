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

    private Rigidbody2D rb;
    public float healthCount;

    private Attack attackScript;

    private Color defaultColor;
    public Color deathColor;

    public static float maxHealth;
    private SpriteRenderer sr;


    // Use this for initialization
    void Start () {
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
    void Update () {


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        

        if(Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            rb.velocity = new Vector2(0, jumpHeight);
        }


        if (sr.color == deathColor)
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
            // SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
           Debug.Log("Player One Wins!");
        }

        flipScale();
    }


    public void flipScale()
    {
        if (rb.velocity.x < 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(rb.velocity.x > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
