using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Block : MonoBehaviour {

    public bool block;
    public KeyCode key;
    private Rigidbody2D rb;
   // public bool blockCoolDown;
   // public float blockTimer;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(key))
        {
            block = true;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
            block = false;
        }
	}
}
