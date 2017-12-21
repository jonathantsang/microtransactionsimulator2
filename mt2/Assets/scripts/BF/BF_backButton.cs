using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BF_backButton : MonoBehaviour {

	private BF_CameraMovement camera;
	private BF_StateController stateController;

	void Start()
	{
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<BF_CameraMovement> ();
		stateController = GameObject.FindGameObjectWithTag ("StateController").GetComponent<BF_StateController> ();
			
		// Button
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener (goBack);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void goBack(){
		Debug.Log ("move camera");
		// coroutine handles changing state because it is async
		StartCoroutine (camera.BackMovement ());
	}
}
