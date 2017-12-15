﻿using UnityEngine;
using System.Collections;

public class panelopen : MonoBehaviour {
	Animation animation;
	Animator animator;

	void Start(){
		animation = GetComponent<Animation> ();
		animator = GetComponent<Animator> ();
	}

	public void open(){
		Debug.Log("PrintEvent: " + "open" + " called at: " + Time.time);
	}

	void Update(){
		if (Input.GetKeyDown ("o")) {
			Debug.Log ("opening");
			animator.SetTrigger ("opening");
		}
	}
}