using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabPageHowToButton : MonoBehaviour {

	public GameObject Popup;

	// Use this for initialization
	void Start () {
		Button btn = GetComponent<Button> ();
		btn.onClick.AddListener (Clicked);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Clicked(){
		Instantiate (Popup, new Vector3 (), Quaternion.identity);
	}
}
