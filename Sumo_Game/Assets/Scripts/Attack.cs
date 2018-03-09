using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject attackTrigger;
    public KeyCode attackKey;
    public bool isAttacking;
    private float attackTimer;
    public int damage = 0;

    
    

	// Use this for initialization
	void Start () {
        attackTrigger.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        attackTrigger.SetActive(isAttacking);
        if (Input.GetKeyDown(attackKey))
        {
            isAttacking = true;
        }

        if (isAttacking)
        {
            attackTimer += Time.deltaTime;
        }

        if(attackTimer >= 1)
        {
            isAttacking = false;
            attackTimer = 0;
        }
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject go;

        if (collision.CompareTag("Player Two"))
        {
            Debug.Log(collision);
            go = collision.gameObject;
            Debug.Log(go);
            go.GetComponent<PlayerTwoMovement>().healthCount -= damage;
        }

        if (collision.CompareTag("Player"))
        {
            Debug.Log(collision);
            go = collision.gameObject;
            Debug.Log(go);
            go.GetComponent<PlayerOneMovement>().healthCount -= damage;
        }
    }

}


