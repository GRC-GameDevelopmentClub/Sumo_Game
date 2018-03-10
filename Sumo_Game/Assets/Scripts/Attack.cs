﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject attackTrigger;
    public KeyCode attackKey;
    public bool isAttacking;
    private float attackTimer;
    public float damage;

    public KeyCode blockKey;
    public bool isBlocking;
    private float blockTimer;


    
    

	// Use this for initialization
	void Start () {
        attackTrigger.SetActive(false);
        isBlocking = false;
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

        if(attackTimer >= 1)
        {
            isAttacking = false;
            attackTimer = 0;
        }

        if (Input.GetKey(blockKey))
        {
            isBlocking = true;
        }

        if (Input.GetKeyUp(blockKey))
        {
            isBlocking = false;
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

            if (!go.GetComponent<Attack>().isBlocking){
                go.GetComponent<PlayerTwoMovement>().healthCount -= damage;
            }

            
        }

        if (collision.CompareTag("Player"))
        {
            Debug.Log(collision);
            go = collision.gameObject;
            Debug.Log(go);

            if (!go.GetComponent<Attack>().isBlocking)
            {
                go.GetComponent<PlayerTwoMovement>().healthCount -= damage;
            }
        }
    }

}


