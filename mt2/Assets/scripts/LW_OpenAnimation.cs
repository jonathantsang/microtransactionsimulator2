using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LW_OpenAnimation : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		animator.SetTrigger ("LW_Open");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CardFlip(){
		//
	}
}
