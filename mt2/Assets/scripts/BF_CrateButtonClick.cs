using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BF_CrateButtonClick : MonoBehaviour {

	private BF_CameraMovement camera;

	void Start()
	{
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<BF_CameraMovement> ();

		// Button
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener (OpenAnimation);
		btn.onClick.AddListener (MoveCamera);
	}

	void MoveCamera(){
		Debug.Log ("move camera");
		StartCoroutine (camera.OpenCrateMovement ());
	}

	void OpenAnimation(){
		Debug.Log ("open animation");
		// open panels
		GameObject[] panels = GameObject.FindGameObjectsWithTag("panel");
		for (int i = 0; i < panels.Length; i++) {
			panels [i].GetComponent<panelopen> ().OpenAnimation ();
		}
		// State should be 1 (for opening crates)

	}




}
