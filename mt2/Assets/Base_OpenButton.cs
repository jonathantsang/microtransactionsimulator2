using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base_OpenButton : MonoBehaviour {

	Button btn;
	CardCreatorController CCC;

	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (generateCards);

		CCC = GameObject.FindGameObjectWithTag ("CardCreatorController").GetComponent<CardCreatorController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void generateCards(){
		// call the cardcreatorcontroller
		CCC.createCards();
	}
}
