using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    public Text healthText;
    public GameObject p1;
    public GameObject p2;

    private PlayerMovement p1Script;
    private PlayerMovement p2Script;

	// Use this for initialization
	void Start () {
        p1Script = p1.GetComponent<PlayerMovement>();
        p2Script = p2.GetComponent<PlayerMovement>();
        healthText.text = "Player 1: " + p1Script.healthCount + " Player 2: " + p2Script.healthCount;
    }
	
	// Update is called once per frame
	void Update () {
        healthText.text = "Player 1: " + p1Script.healthCount + " Player 2: " + p2Script.healthCount;
    }
}
