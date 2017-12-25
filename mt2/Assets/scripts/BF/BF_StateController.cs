using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BF_StateController : MonoBehaviour {

	// 0 crate selection, 1 crate contents
	int state;

	// Changing elements
	GameObject crateUI;
	GameObject backButton;
	GameObject OpenAllButton;

	// Use this for initialization
	void Start () {
		// Start at crate selection
		state = 0;
		crateUI = GameObject.FindGameObjectWithTag ("crateUI");
		backButton = GameObject.FindGameObjectWithTag ("backButton");
		OpenAllButton = GameObject.FindGameObjectWithTag ("OpenAllButton");

		// initial state
		// turn on crateUI
		crateUI.SetActive(true);
		// turn off back button
		backButton.SetActive(false);
		// turn off open all button
		OpenAllButton.SetActive(false);
	}

	public void changeState(int i){
		if (i == 0) {
			// turn on crateUI
			crateUI.SetActive(true);
			// turn off back button
			backButton.SetActive(false);
			// turn off open all button
			OpenAllButton.SetActive(false);
		} else if (i == 1) {
			// turn off crateUI
			crateUI.SetActive(false);
			// turn on back button
			backButton.SetActive(true);
			// turn on open all button
			OpenAllButton.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
