using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DOH_OpenButton : MonoBehaviour {

	static float wait = 5f;
	GameObject CardPlaces;
	GameObject CardHolder;

	InventoryController IC;
	DOH_RNGController RNGC;
	ItemDirectoryController IDC;

	public GameObject Chest;
	public GameObject Card;

	// Use this for initialization
	void Start () {
		// Linking
		CardPlaces = GameObject.FindGameObjectWithTag ("CardPlaces").gameObject;
		CardHolder = GameObject.FindGameObjectWithTag ("CardHolder").gameObject;
		IC = GameObject.FindGameObjectWithTag ("InventoryController").GetComponent<InventoryController> ();
		RNGC = GameObject.FindGameObjectWithTag ("RNGController").GetComponent<DOH_RNGController> ();
		IDC = GameObject.FindGameObjectWithTag ("ItemDirectoryController").GetComponent<ItemDirectoryController> ();

		Button btn = GetComponent<Button> ();
		btn.onClick.AddListener (MakeCards);
	}
	
	// Update is called once per frame
	void Update () {
		wait += Time.deltaTime;
	}

	void MakeCards(){
		if (wait >= 5) {
			wait = 0;
		} else {
			return;
		}

		// Destroy old cards
		for(int i = 0; i < CardHolder.transform.childCount; i++){
			Destroy(CardHolder.transform.GetChild(i).gameObject);
		}
		// Drop Chest
		GameObject ChestDropped = Instantiate(Chest, new Vector3(1,7,1), Quaternion.identity);
		Destroy (ChestDropped, 3f);
		// Check IC for how many to open
		int amount = IC.getHowManyToOpen();

		// Create the cards
		for(int i = 0; i < amount; i++){
			GameObject newcard = Instantiate (Card, CardPlaces.transform.GetChild(i).transform.position, Quaternion.identity);
			// Roll RNG
			int id = RNGC.getRandom();

			// Set icon of card
			newcard.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = IDC.getSprite(id);
			IC.AddToInventory (id);

			newcard.transform.SetParent (CardHolder.transform);
		}

		// Increment IC
		IC.IncrementNumberOpened();

	}
}
