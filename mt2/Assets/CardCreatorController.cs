using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCreatorController : MonoBehaviour {

	BaseRNGController BRNG;
	GameObject cardHolder;
	InventoryController IC;
	SpriteStorageController SSC;

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

		// Set the back based on the rarity
		int cn1 = BRNG.getColourIndexFromNumber(n1);
		int cn2 = BRNG.getColourIndexFromNumber(n2);
		int cn3 = BRNG.getColourIndexFromNumber(n3);
		int cn4 = BRNG.getColourIndexFromNumber(n4);

		// get the backing colour
		cardHolder.transform.GetChild (0).GetChild (0).GetComponent<Image>().sprite = SSC.getCardColour(cn1);
		cardHolder.transform.GetChild (1).GetChild (0).GetComponent<Image>().sprite = SSC.getCardColour(cn2);
		cardHolder.transform.GetChild (2).GetChild (0).GetComponent<Image>().sprite = SSC.getCardColour(cn3);
		cardHolder.transform.GetChild (3).GetChild (0).GetComponent<Image>().sprite = SSC.getCardColour(cn4);

		// Set the collider info, so when it is clicked it can make the Card Object
		cardHolder.transform.GetChild (0).GetComponent<CardCollider>().setValueAndColourIndex(n1, cn1);
		cardHolder.transform.GetChild (1).GetComponent<CardCollider>().setValueAndColourIndex(n2, cn2);
		cardHolder.transform.GetChild (2).GetComponent<CardCollider>().setValueAndColourIndex(n3, cn3);
		cardHolder.transform.GetChild (3).GetComponent<CardCollider>().setValueAndColourIndex(n4, cn4);

		// Save to the Inventory only when clicked... hmmm
		IC.addCard (new Card (n1, cn1));
		IC.addCard (new Card (n2, cn2));
		IC.addCard (new Card (n3, cn3));
		IC.addCard (new Card (n4, cn4));
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
		if (BRNG == null) {
			BRNG = GameObject.FindGameObjectWithTag ("RNGController").GetComponent<BaseRNGController> ();
		}
		if (IC == null) {
			IC = GameObject.FindGameObjectWithTag ("InventoryController").GetComponent<InventoryController> ();
		}
		if (cardHolder == null) {
			cardHolder = GameObject.FindGameObjectWithTag ("CardHolder").gameObject;
		}
		if (SSC == null) {
			SSC = GameObject.FindGameObjectWithTag ("SpriteStorageController").GetComponent<SpriteStorageController> ();
		}
	}
}
