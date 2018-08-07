using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCreatorController : MonoBehaviour {

	BaseRNGController BRNG;
	GameObject cardHolder;
	InventoryController IC;

	// Use this for initialization
	void Start () {
		publicMethodLink ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void createCards(){
		// Public usage needs to check for linking before
		publicMethodLink();

		// Delete the old cards (aka just activate the backs again)
		activateCardBacks();

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

		// Save to the Inventory only when clicked... hmmm
		IC.addCard (new Card (n1));
		IC.addCard (new Card (n2));
		IC.addCard (new Card (n3));
		IC.addCard (new Card (n4));
	}

	void activateCardBacks(){
		// Set cardBack on all the cards
		cardHolder.transform.GetChild (0).GetComponent<CardCollider>().setCardBackState(true);
		cardHolder.transform.GetChild (1).GetComponent<CardCollider>().setCardBackState(true);
		cardHolder.transform.GetChild (2).GetComponent<CardCollider>().setCardBackState(true);
		cardHolder.transform.GetChild (3).GetComponent<CardCollider>().setCardBackState(true);

		// Set flipped on all the cards to false
		cardHolder.transform.GetChild (0).GetComponent<CardCollider>().setFlipped(false);
		cardHolder.transform.GetChild (1).GetComponent<CardCollider>().setFlipped(false);
		cardHolder.transform.GetChild (2).GetComponent<CardCollider>().setFlipped(false);
		cardHolder.transform.GetChild (3).GetComponent<CardCollider>().setFlipped(false);
	}

	void publicMethodLink(){
		BRNG = GameObject.FindGameObjectWithTag ("RNGController").GetComponent<BaseRNGController> ();
		IC = GameObject.FindGameObjectWithTag ("InventoryController").GetComponent<InventoryController> ();
		cardHolder = GameObject.FindGameObjectWithTag ("CardHolder").gameObject;
	}
}
