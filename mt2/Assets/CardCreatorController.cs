using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCreatorController : MonoBehaviour {

	Base_RNGController BRNG;
	GameObject cardHolder;

	// Use this for initialization
	void Start () {
		BRNG = GameObject.FindGameObjectWithTag ("RNGController").GetComponent<Base_RNGController> ();
		cardHolder = GameObject.FindGameObjectWithTag ("CardHolder").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void createCards(){
		// Roll the RNG
		int number = BRNG.rollNumber();

		// form the cards
		cardHolder.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "12";
		cardHolder.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "12";
		cardHolder.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "12";
		cardHolder.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "12";
	}
}
