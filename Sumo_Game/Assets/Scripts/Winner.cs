using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winner : MonoBehaviour {

    public Text winBoi;
    private Score scoreKeeper;
	// Use this for initialization
	void Start () {
        scoreKeeper = FindObjectOfType<Score>();
        winBoi.text = scoreKeeper.GetWinner() + " is da win boiii!!";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
