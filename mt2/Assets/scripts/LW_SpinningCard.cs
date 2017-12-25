using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LW_SpinningCard : MonoBehaviour {

	float upwards = 400f;
	float spin = 300f;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();	
		rb.AddForce (Vector3.up * upwards); // push up
		rb.AddTorque (Vector3.right * spin); // spin forward
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
