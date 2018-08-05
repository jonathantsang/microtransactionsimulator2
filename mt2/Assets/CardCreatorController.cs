using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCreatorController : MonoBehaviour {

	Base_RNGController BRNG;
	GameObject cardHolder;
	InventoryController IC;

	// Use this for initialization
	void Start () {
		BRNG = GameObject.FindGameObjectWithTag ("RNGController").GetComponent<Base_RNGController> ();
		cardHolder = GameObject.FindGameObjectWithTag ("CardHolder").gameObject;
		IC = GameObject.FindGameObjectWithTag ("InventoryController").GetComponent<InventoryController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void createCards(){
		// Roll the RNG
		int n1 = BRNG.rollNumber();
		int n2 = BRNG.rollNumber();
		int n3 = BRNG.rollNumber();
		int n4 = BRNG.rollNumber();

		// form the cards
		cardHolder.transform.GetChild (0).GetChild (1).GetComponent<Text> ().text = n1.ToString ();
		cardHolder.transform.GetChild (1).GetChild (1).GetComponent<Text> ().text = n2.ToString ();
		cardHolder.transform.GetChild (2).GetChild (1).GetComponent<Text> ().text = n3.ToString ();
		cardHolder.transform.GetChild (3).GetChild (1).GetComponent<Text> ().text = n4.ToString ();

		// Save to the Inventory
		IC.addCard (new Card (n1));
		IC.addCard (new Card (n2));
		IC.addCard (new Card (n3));
		IC.addCard (new Card (n4));

	}
}
