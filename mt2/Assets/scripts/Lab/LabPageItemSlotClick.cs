using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabPageItemSlotClick : MonoBehaviour {

	// refers to 0 or 2 for each slot
	int id;
	// refers to the ID of the ITEM at the slot
	int itemID;

	LabPageSelectedController LPSC;

	// Use this for initialization
	void Start () {
		LPSC = GameObject.FindGameObjectWithTag ("SelectedController").GetComponent<LabPageSelectedController> ();

	}

	void OnMouseDown(){
		LPSC.SelectSlot (id);
	}

	public void setID(int i){
		id = i;
	}

	public int getID(){
		return id;
	}

	public void setItemID(int i){
		itemID = i;
	}

	public int getItemID(){
		return itemID;
	}

	public void ResetItemID(){
		itemID = -1;
	}
		
}
