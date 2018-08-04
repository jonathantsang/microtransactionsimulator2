using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LW_SpinningCard : MonoBehaviour {

	float upwards = 2f;
	float downwards = 3f;
	float spin = 300f;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveDisc(){
		rb = GetComponent<Rigidbody> ();
		rb.AddForce(Vector3.forward * 150);
		rb.velocity = Vector3.up * upwards; // push up
		rb.AddTorque (Vector3.right * spin); // spin forward
		Destroy(gameObject, 4f);
	}
}
