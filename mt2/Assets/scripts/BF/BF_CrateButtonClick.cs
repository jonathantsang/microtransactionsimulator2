using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BF_CrateButtonClick : MonoBehaviour {

	private BF_CameraMovement camera;
	private BF_RNGController RNGcontroller;

	// two bools for two button functions
	private bool clicked = false;

	void Start()
	{
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<BF_CameraMovement> ();

		// Button
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener (OpenAnimation);
		btn.onClick.AddListener (MoveCamera);
		btn.onClick.AddListener (CreateCrates);
	}

	void MoveCamera(){
		// sets the state after the camera has moved
		StartCoroutine (camera.OpenCrateMovement ());
	}

	void OpenAnimation(){
		Debug.Log ("open animation");
		// open panels
		GameObject[] panels = GameObject.FindGameObjectsWithTag("panel");
		for (int i = 0; i < panels.Length; i++) {
			panels [i].GetComponent<BF_panelopen> ().OpenAnimation ();
		}
	}

	void CreateCrates(){
		// call random
		int id = RNGcontroller.getRandom();
		// materialize the crates on the screen ui

		// click to open

	}

}
