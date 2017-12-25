using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BF_backButton : MonoBehaviour {

	private BF_CameraMovement camera;
	private GameObject Cards;

	void Start()
	{
		Cards = GameObject.FindGameObjectWithTag ("CardHolder").gameObject;
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<BF_CameraMovement> ();
			
		// Button
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener (goBack);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void goBack(){
		Debug.Log ("move camera");
		// Delete the cards
		for(int i = 0; i < Cards.transform.childCount; i++){
			Destroy (Cards.transform.GetChild (i).gameObject);
		}

		// coroutine handles changing state because it is async
		StartCoroutine (camera.BackMovement ());
	}
}
