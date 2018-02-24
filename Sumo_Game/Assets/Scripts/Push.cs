using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour {

    public GameObject pushTrigger;
    public KeyCode pushKey;

	// Use this for initialization
	void Start () {
        pushTrigger.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(pushKey))
        {
            pushTrigger.SetActive(true);

        }
        else
        {
            pushTrigger.SetActive(false);
        }
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go;

        if (collision.CompareTag("Player Two"))
        {
            go = collision.gameObject;
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000, 1000));
        }

        if (collision.CompareTag("Player"))
        {
            go = collision.gameObject;
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000, -1000));
        }
    }




}


