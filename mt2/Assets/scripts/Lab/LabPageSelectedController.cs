using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabPageSelectedController : MonoBehaviour {

	// Person clicks on a space in the equation, last one pressed it puts the item there
	int previousID = -1;
	int previousSlot = -1;
	LabController LC;
	InventoryController IC;
	GameObject SlotOne;
	GameObject SlotTwo;

	// Use this for initialization
	void Start () {
		SlotOne = GameObject.FindGameObjectWithTag ("RightPanel").transform.GetChild (0).gameObject;
		SlotTwo = GameObject.FindGameObjectWithTag ("RightPanel").transform.GetChild (2).gameObject;

		IC = GameObject.FindGameObjectWithTag ("InventoryController").GetComponent<InventoryController> ();
		LC = GameObject.FindGameObjectWithTag ("LabController").GetComponent<LabController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SelectItem(int id){
		if (id == -1) {
			return;
		}
		// NEED to check IC has collected the item, and it has at least 1 to count as valid selection
		if(!IC.checkCollected(id) || IC.getCollectedAmount(id) < 1){
			return;
		}

		Debug.Log ("selected item " + id);

		// selected slot first, put the item id in the slot
		if (previousSlot != -1) {
			// IF it is already used in one slot, and it has only 1 it is possible to use 1 for two slots
			// inputting id into previousSLOT, so check the other one to see if it is the same id AND IC.getCollectedAmount(id) == 1
			int other = Mathf.Abs(previousSlot - 1);
			int checkID = 0;
			if (other == 0) {
				checkID = SlotOne.transform.GetChild (1).GetComponent<LabPageItemSlotClick> ().getItemID ();
			} else if (other == 1) {
				checkID = SlotTwo.transform.GetChild (1).GetComponent<LabPageItemSlotClick> ().getItemID ();
			}
			Debug.Log (checkID);
			if (IC.getCollectedAmount (id) == 1 && checkID == id) {
				Debug.Log("Edge case fixed of splitting 1");
				return;
			}

			// input the slot as previousID
			Debug.Log ("slot " + previousSlot + " puts " + id);
			LC.InputSlot (previousSlot, id);
			clear ();
		} else {
			previousID = id;
		}

	}

	public void SelectSlot(int id){
		if (id == -1) {
			return;
		}
		// do stuff

		// selected item first, put the previousID into id slot
		if (previousID != -1) {
			// IF it is already used in one slot, and it has only 1 it is possible to use 1 for two slots
			// inputting previousID into id slot, so check the other one to see if it is the same id AND IC.getCollectedAmount(id) == 1
			int other = Mathf.Abs(id - 1);
			int checkID = 0;
			if (other == 0) {
				checkID = SlotOne.transform.GetChild (1).GetComponent<LabPageItemSlotClick> ().getItemID ();
			} else if (other == 1) {
				checkID = SlotTwo.transform.GetChild (1).GetComponent<LabPageItemSlotClick> ().getItemID ();
			}
			Debug.Log (checkID);
			if (IC.getCollectedAmount (previousID) == 1 && checkID == previousID) {
				Debug.Log("Edge case fixed of splitting 1");
				return;
			}
				
			// input the slot as previousID
			Debug.Log ("slot " + id + " puts " + previousID);
			LC.InputSlot (id, previousID);
			clear ();
		} else {
			previousSlot = id;
		}

	}

	void clear(){
		previousID = -1;
		previousSlot = -1;
	}
}
