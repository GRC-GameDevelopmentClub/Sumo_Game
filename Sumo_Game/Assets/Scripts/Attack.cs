using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attack : MonoBehaviour {

    public GameObject attackTrigger;
    public KeyCode attackKey;
    public bool isAttacking;
    private float attackTimer;
    public float damage;

    public KeyCode blockKey;
    public bool isBlocking;
    public Color blockColor;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        attackTrigger.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        attackTrigger.SetActive(isAttacking);
        if (Input.GetKeyDown(attackKey) && !isBlocking)
        {
            isAttacking = true;
        }

        if (isAttacking)
        {
            attackTimer += Time.deltaTime;
        }

        if(attackTimer >= 0.25)
        {
            isAttacking = false;
            attackTimer = 0;
        }

        if (Input.GetKey(blockKey))
        {
            isBlocking = true;
            rb.velocity = new Vector2(0, rb.velocity.y);
            this.GetComponentInChildren<SpriteRenderer>().color = blockColor;
        }
        else
        {
            isBlocking = false;
        }
        
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject go;

        if (collision.CompareTag("Player"))
        {
            go = collision.gameObject;

            go.GetComponentInChildren<SpriteRenderer>().color = go.GetComponent<PlayerMovement>().deathColor;
            if (go.GetComponent<Attack>().isBlocking)
            {
                go.GetComponent<PlayerMovement>().healthCount -= (damage * 0.5f);
            }else
            {
                go.GetComponent<PlayerMovement>().healthCount -= damage;
            }

        }

    }

}


