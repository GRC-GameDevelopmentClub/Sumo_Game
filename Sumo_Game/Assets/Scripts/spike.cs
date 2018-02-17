using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spike: MonoBehaviour {
	public int damage;

	// Use this for initialization
	void Start () 
	{
		damage = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			damage=10;
		}
	}
}

/* damage=0, if the player touch the trap, player get damage to 10 points
 * it have collision with player, and it is fixed trap:spike.
 * 
 * damage=0-> player collide with trap->collision!->get damage of 10.
 * ->damage affect to player's life.
 * (assume the originally player has 100 points)*/