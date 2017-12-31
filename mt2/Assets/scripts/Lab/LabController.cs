using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Responsible for SETTING UP the Lab Page
public class LabController : MonoBehaviour {

	GameObject Content;
	GameObject TopPanel;
	GameObject SlotOne; // slot one
	GameObject SlotTwo; // slot two
	GameObject ResultSlot;

	InventoryController IC;
	ItemDirectoryController IDC;
	int rowLength = 10;

	// Use this for initialization
	void Start () {
		// Linking
		IC = GameObject.FindGameObjectWithTag("InventoryController").GetComponent<InventoryController>();
		IDC = GameObject.FindGameObjectWithTag ("ItemDirectoryController").GetComponent<ItemDirectoryController> ();
		Content = GameObject.FindGameObjectWithTag ("Content").gameObject;
		TopPanel = GameObject.FindGameObjectWithTag ("RightPanel").gameObject; // Correct tag, just reuse
		SlotOne = TopPanel.transform.GetChild(0).gameObject;
		SlotTwo = TopPanel.transform.GetChild(2).gameObject;
		ResultSlot = TopPanel.transform.GetChild(4).transform.GetChild(1).gameObject;

		// Load
		LoadLab ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadLab(){
		// Populate the Rows of the lab inventory
		for(int i = 0; i < Content.transform.childCount; i++){
			// Go to 0 to 9 (1-10) for each inventory item
			for(int j = 0; j < rowLength; j++){
				int id = i * rowLength + j;
				// LPSC
				Content.transform.GetChild(i).transform.GetChild(j).GetComponent<LabPageClick>().setID(id);
				// icon
				Image image = Content.transform.GetChild(i).transform.GetChild(j).GetComponent<Image>();
				// count (1) child is text
				Text count = Content.transform.GetChild(i).transform.GetChild(j).transform.GetChild(1).GetComponent<Text>();
				if (IC.checkCollected (id)) {
					// use IDC
					image.sprite = IDC.getSprite(id);
					count.text = IC.getCollectedAmount(id).ToString();
				} else {
					count.text = "";
				}
			}
		}
		// Set ID for the item slots so it can be identified
		// Child 0, 1 get the component to set the ID
		SlotOne.transform.GetChild(1).GetComponent<LabPageItemSlotClick>().setID(0);
		SlotTwo.transform.GetChild(1).GetComponent<LabPageItemSlotClick>().setID(1);

		// Set result to -1 so it cannot be affected
		ResultSlot.GetComponent<LabPageItemSlotClick>().setID(-1);
	}

	public void InputSlot(int slot, int id){
		if (slot == 0) {
			// Set slot one to IDC id sprite
			SlotOne.transform.GetChild(1).GetComponent<Image>().sprite = IDC.getSprite(id);
			// Set the Text above
			SlotOne.transform.GetChild(0).GetComponent<Text>().text = IDC.getName(id);
			// set the ID
			SlotOne.transform.GetChild(1).GetComponent<LabPageItemSlotClick>().setItemID(id);
		} else if (slot == 1) {
			// Set slot two to IDC id sprite
			SlotTwo.transform.GetChild(1).GetComponent<Image>().sprite = IDC.getSprite(id);
			// Set the Text above
			SlotTwo.transform.GetChild(0).GetComponent<Text>().text = IDC.getName(id);
			// Set the ID
			SlotTwo.transform.GetChild(1).GetComponent<LabPageItemSlotClick>().setItemID(id);
		}
	}

	public void UpdateCountText(int id){
		int i = id / 10;
		int j = id % 10;
		// Should be decreased since it decrements from the inventory first
		Content.transform.GetChild(i).transform.GetChild(j).transform.GetChild(1).GetComponent<Text>().text = IC.getCollectedAmount(id).ToString();
	}
}
