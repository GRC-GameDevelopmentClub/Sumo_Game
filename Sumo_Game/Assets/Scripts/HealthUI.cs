using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    public Text healthText;
    public GameObject p1;
    public GameObject p2;

    private PlayerOneMovement p1Script;
    private PlayerTwoMovement p2Script;

	// Use this for initialization
	void Start () {
        p1Script = p1.GetComponent<PlayerOneMovement>();
        p2Script = p2.GetComponent<PlayerTwoMovement>();
        healthText.text = "Player 1: " + p1Script.healthCount + " Player 2: " + p2Script.healthCount;
    }
	
	// Update is called once per frame
	void Update () {
        healthText.text = "Player 1: " + p1Script.healthCount + " Player 2: " + p2Script.healthCount;
    }
}
