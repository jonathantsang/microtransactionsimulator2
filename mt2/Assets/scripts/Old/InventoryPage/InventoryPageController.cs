using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryPageController : MonoBehaviour {

	public GameObject row;
	public GameObject inventoryprefab;

	GameObject Inventory;
	InventoryController IC;
	Dictionary<int, int> Collected;
	List<GameObject> ItemTiles;

	// Use this for initialization
	void Start () {
		Inventory = GameObject.FindGameObjectWithTag ("Content").gameObject;
		IC = GameObject.FindGameObjectWithTag ("InventoryController").GetComponent<InventoryController> ();
		Collected = IC.getCollected();
		ItemTiles = new List<GameObject> ();
		LoadInventory ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadInventory(){

		List<Card> cards = IC.getCards ();


		Card[] cardArray = cards.ToArray();
		int idx = 0; // Index of the cards list

		// For each row in the inventory, check if the InventoryController has it unlocked
		for(int i = 0; i < Inventory.transform.childCount; i++){
			// 5 elements per row
			int elementsPerCount = 5;
			for(int j = 0; j < elementsPerCount; j++){
				int id = i * 5 + j; // Gets the index based on the positioning

				// Load card from the inventory controller
				int textIndex = 1;

				// End
				if (idx >= cards.Count) {
					return;
				}

				Text cardText = Inventory.transform.GetChild (i).GetChild (j).GetChild (textIndex).GetComponent<Text> ();

				cardText.text = (cardArray [idx]).getValue().ToString();
				idx++;
			}
		}
	}

	public GameObject getItemTile(int i){
		return ItemTiles [i];
	}
}
