using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseOpenButton : MonoBehaviour {

	Button btn;
	CardCreatorController CCC;
	LoadingScreenController LSC;

	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (generateCards);

		CCC = GameObject.FindGameObjectWithTag ("CardCreatorController").GetComponent<CardCreatorController> ();
		LSC = GameObject.FindGameObjectWithTag ("LoadingScreenController").GetComponent<LoadingScreenController> ();
		generateCardsFirstTime (); // at the start
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void generateCards(){
		// call the cardcreatorcontroller
		CCC.createCards();
		LSC.turnOnLoadingScreen ();
	}

	void generateCardsFirstTime(){
		CCC.createCards();
	}
}
