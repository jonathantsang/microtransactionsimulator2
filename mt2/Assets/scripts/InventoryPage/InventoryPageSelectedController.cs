using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPageSelectedController : MonoBehaviour {

	public Sprite locked;

	int previousID;
	InventoryController IC;
	ItemDirectoryController IDC;
	InventoryPageController IPC;
	GameObject RightPanel;

	// Use this for initialization
	void Start () {
		IC = GameObject.FindGameObjectWithTag ("InventoryController").GetComponent<InventoryController> ();
		IPC = GameObject.FindGameObjectWithTag ("InventoryPageController").GetComponent<InventoryPageController> ();
		IDC = GameObject.FindGameObjectWithTag ("ItemDirectoryController").GetComponent<ItemDirectoryController> ();
		RightPanel = GameObject.FindGameObjectWithTag ("RightPanel").gameObject;
		previousID = -1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SelectItem(int id){
		if (previousID != -1) {
			// Turn off previous ID selected
			InventoryPageClick tile = IPC.getItemTile(previousID).GetComponent<InventoryPageClick>();
			tile.Deselect();
		}
		// Name
		Text name = RightPanel.transform.GetChild (0).GetComponent<Text>();
		// Image
		Image image = RightPanel.transform.GetChild (1).GetComponent<Image>();
		// Description
		Text description = RightPanel.transform.GetChild (2).GetComponent<Text>();
		// Amount
		Text amount = RightPanel.transform.GetChild(3).GetComponent<Text>();

		// check if it has been collected
		if (IC.checkCollected (id)) {
			Item item = IDC.getItem (id);
			// set the selected rect
			InventoryPageClick tile = IPC.getItemTile(id).GetComponent<InventoryPageClick>();
			tile.Select ();
			previousID = id;

			name.text = item.getName();
			image.sprite = IDC.getSprite (id);
			description.text = item.getDescription ();
			if (IC.getCollectedAmount (id) > 99) {
				amount.text = "99+";
			} else {
				amount.text = IC.getCollectedAmount (id).ToString ();
			}
		} else {
			// set the selected rect
			InventoryPageClick tile = IPC.getItemTile(id).GetComponent<InventoryPageClick>();
			tile.Select ();
			previousID = id;

			// not collected, so set as default
			name.text = "Locked";
			image.sprite = locked;
			description.text = "Locked";
			amount.text = "0";
		}


	}
}
