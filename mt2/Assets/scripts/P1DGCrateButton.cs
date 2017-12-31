using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class P1DGCrateButton : MonoBehaviour {

	public GameObject card;
	GameObject CardPlaces;
	GameObject CardHolder;

	InventoryController IC;
	ItemDirectoryController IDC;
	P1DG_RNGController PRC;

	// Use this for initialization
	void Start () {
		// Linking
		IC = GameObject.FindGameObjectWithTag("InventoryController").GetComponent<InventoryController>();
		IDC = GameObject.FindGameObjectWithTag ("ItemDirectoryController").GetComponent<ItemDirectoryController> ();
		PRC = GameObject.FindGameObjectWithTag ("RNGController").GetComponent<P1DG_RNGController> ();
		CardPlaces = GameObject.FindGameObjectWithTag("CardPlaces").gameObject;
		CardHolder = GameObject.FindGameObjectWithTag ("CardHolder").gameObject;

		Button btn = GetComponent<Button> ();
		btn.onClick.AddListener (CreateCards);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateCards(){
		// Delete old CardHolder cards
		for(int i = 0; i < CardHolder.transform.childCount; i++){
			Destroy(CardHolder.transform.GetChild(i).gameObject);
		}

		// Create amount
		int OpenAmount = IC.getHowManyToOpen();
		for (int i = 0; i < OpenAmount; i++) {
			GameObject newcard = Instantiate (card, CardPlaces.transform.GetChild (i).position, Quaternion.identity);

			int id = PRC.getRandom ();
			// Set the icon
			newcard.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = IDC.getSprite(id);

			// Add to the inventory
			IC.AddToInventory(id);

			newcard.transform.SetParent (CardHolder.transform);
		}
	}
}
