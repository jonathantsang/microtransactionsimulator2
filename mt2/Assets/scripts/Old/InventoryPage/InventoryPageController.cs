using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryPageController : MonoBehaviour {

	public GameObject row;
	public GameObject inventoryprefab;

	GameObject Inventory;
	InventoryController IC;
	ItemDirectoryController IDC;
	Dictionary<int, int> Collected;
	List<GameObject> ItemTiles;

	// Use this for initialization
	void Start () {
		Inventory = GameObject.FindGameObjectWithTag ("Content").gameObject;
		IC = GameObject.FindGameObjectWithTag ("InventoryController").GetComponent<InventoryController> ();
		IDC = GameObject.FindGameObjectWithTag ("ItemDirectoryController").GetComponent<ItemDirectoryController> ();
		Collected = IC.getCollected();
		ItemTiles = new List<GameObject> ();
		LoadInventory ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadInventory(){
		// For each row in the inventory, check if the InventoryController has it unlocked
		for(int i = 0; i < Inventory.transform.childCount; i++){
			// 5 elements per row
			int rowCount = 5;
			for(int j = 0; j < rowCount; j++){
				int id = i * 5 + j; // Gets the index based on the positioning

				// Load the ID into the InventoryPageClick
				Inventory.transform.GetChild(i).transform.GetChild(j).GetComponent<InventoryPageClick>().setID(id);
				ItemTiles.Add (Inventory.transform.GetChild (i).transform.GetChild (j).gameObject);

				// Only edit thumbnail if it has been collected
				if (Collected.ContainsKey(id) && Collected[id] >= 0) {
					// change icon
					Image icon = Inventory.transform.GetChild (i).transform.GetChild (j).GetComponent<Image>();
					icon.sprite = IDC.getSprite(id);
				}
			}
		}
	}

	public GameObject getItemTile(int i){
		return ItemTiles [i];
	}
}
