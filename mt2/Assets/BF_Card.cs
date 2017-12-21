using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BF_Card : MonoBehaviour {
	Animation animation;
	Animator animator;
	GameObject Front;
	GameObject Opened;

	// Use this for initialization
	void Start () {
		Front = gameObject;
		Opened = transform.parent.transform.GetChild (1).gameObject; // Opened is sibling of card
		animation = GetComponent<Animation> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Manually click it
	void OnMouseDown()
	{
		openCard ();
	}

	void openCard(){
		// Set rotation animation
		Debug.Log("flip card");
		animator.SetTrigger ("Flip");
	}
		
}
