using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {
	public float damage;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		GameObject GO;
		Debug.Log ("fire!");
		//player1
		if (collision.gameObject.CompareTag("Player"))
		{
			GO = collision.gameObject;
			GO.GetComponent<PlayerOneMovement> ().healthCount -= damage;

		}

		//player2
		if (collision.gameObject.CompareTag("Player Two"))
		{
			GO = collision.gameObject;
			GO.GetComponent<PlayerTwoMovement> ().healthCount -= damage;

		}
	}
}
