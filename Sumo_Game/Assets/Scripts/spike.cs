﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spike: MonoBehaviour {
	public float damage;

	// Use this for initialization
	void Start () 
	{
		damage = 10;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log ("healthCount");
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		GameObject GO;
		Debug.Log ("HURT!");
		//player1
		if (collision.gameObject.CompareTag("Player"))
		{
			GO = collision.gameObject;
			GO.GetComponent<PlayerMovement>().healthCount -= damage;
		}

	}
}

/* damage=0, if the player touch the trap, player get damage to 10 points
 * it have collision with player, and it is fixed trap:spike.
 * 
 * damage=0-> player collide with trap->collision!->get damage of 10.
 * ->damage affect to player's life.
 * (assume the originally player has 100 points)*/