using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    private string winner;
    private float damageTaken;

    public GameObject p1;
    private PlayerMovement p1Script;

    public GameObject p2;
    private PlayerMovement p2Script;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);

        p1Script = p1.GetComponent<PlayerMovement>();
        p2Script = p2.GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {

        if (p1Script != null && p2Script != null)
        {
            if (p1Script.healthCount > p2Script.healthCount)
            {
                winner = p1Script.name;
            }
            else
            {
                winner = p2Script.name;
            }
        }
	}

    public void SetWinner(string winner)
    {
        this.winner = winner;
    }
    
    public string GetWinner()
    {
        return winner;
    }
}
