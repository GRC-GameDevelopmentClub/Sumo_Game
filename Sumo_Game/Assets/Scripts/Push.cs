using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour {

    public GameObject pushTrigger;
    public KeyCode pushKey;
    private Vector2 direction;
    private bool isPushing;
    private float pushTimer;

	// Use this for initialization
	void Start () {
        pushTrigger.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        pushTrigger.SetActive(isPushing);
        if (Input.GetKeyDown(pushKey))
        {
            isPushing = true;
            
        }

        if (isPushing)
        {
            pushTimer += Time.deltaTime;
        }

        if(pushTimer >= 1)
        {
            isPushing = false;
            pushTimer = 0;
        }


        Debug.Log(this.tag + "  Veocity: "+ GetComponent<Rigidbody2D>().velocity);
        Debug.Log("Diretion"+direction);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go;

        if (collision.CompareTag("Player Two"))
        {
            go = collision.gameObject;
            direction = (go.transform.position - this.transform.position);
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000 * direction.x, 20000 * direction.y));
            Debug.Log("Collision");
            
        }

        if (collision.CompareTag("Player"))
        {
            go = collision.gameObject;
            direction = (go.transform.position - this.transform.position).normalized;
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000 * direction.x, 200 * direction.y));

        }
    }




}


