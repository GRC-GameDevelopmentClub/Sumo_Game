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

    Vector2 direction;
    public float pushForce;

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

            PlayerMovement script = go.GetComponent<PlayerMovement>();
            direction = (go.transform.position - this.transform.position);

            go.GetComponentInChildren<SpriteRenderer>().color = go.GetComponent<PlayerMovement>().deathColor;
            if (go.GetComponent<Attack>().isBlocking)
            {
                script.healthCount -= (damage * 0.5f);
                
            }else
            {
                script.healthCount -= damage;
                float pushMulti = script.maxHealth / script.healthCount;
                go.GetComponent<Rigidbody2D>().velocity = direction * pushForce * pushMulti;
            }

        }

    }

}


