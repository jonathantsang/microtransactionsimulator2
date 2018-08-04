using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	float speed = 3f;
	Rigidbody2D rb2d;
	PelletController PC;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		PC = GameObject.FindGameObjectWithTag ("PelletController").GetComponent<PelletController> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 Movement = new Vector3 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		transform.position += Movement * speed * Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Pellet") {
			Destroy (col.gameObject);
			PC.DecrementAmount ();
		} else if (col.gameObject.tag == "InvisibleWall") {
			transform.position = new Vector3 (-6, 5, 0);
		}
	}
}
