using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LW_SpinningCard : MonoBehaviour {

	float upwards = 8f;
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
		rb.velocity = Vector3.up * upwards; // push up
		rb.AddTorque (Vector3.right * spin); // spin forward
	}
}
