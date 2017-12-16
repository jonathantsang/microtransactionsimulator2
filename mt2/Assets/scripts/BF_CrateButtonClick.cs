using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BF_CrateButtonClick : MonoBehaviour {

	private CameraMovement camera;

	void Start()
	{
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraMovement> ();

		// Button
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener (MoveCamera);
	}

	void MoveCamera(){
		Debug.Log ("move camera");
		StartCoroutine (camera.OpenCrateMovement ());
	}




}
