using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeButton : MonoBehaviour {

	InventoryController IC;
	RecipeDirectoryController RDC;
	LabPageItemSlotClick SlotOne;
	LabPageItemSlotClick SlotTwo;

	// Use this for initialization
	void Start () {
		// Linking
		RDC = GameObject.FindGameObjectWithTag("RecipeDirectoryController").GetComponent<RecipeDirectoryController>();
		IC = GameObject.FindGameObjectWithTag ("InventoryController").GetComponent<InventoryController> ();
		SlotOne = GameObject.FindGameObjectWithTag ("RightPanel").transform.GetChild (0).transform.GetChild (1).GetComponent<LabPageItemSlotClick> ();
		SlotTwo = GameObject.FindGameObjectWithTag ("RightPanel").transform.GetChild (2).transform.GetChild (1).GetComponent<LabPageItemSlotClick> ();

		Button btn = GetComponent<Button> ();
		btn.onClick.AddListener (Merge);
	}

	void Merge(){
		// call RDC to check the slots
		int i1 = SlotOne.getItemID ();
		int i2 = SlotTwo.getItemID ();
		Debug.Log("got " + i1 + " " + i2);

		// Checks if it is a valid recipe
		int check = RDC.CheckRecipes(i1, i2);
		if(check != -1){
			Debug.Log("valid recipe");
			// call recipe done in inventory
			IC.AddToRecipes(check);
			// valid recipe
		} else {
			// invalid recipe
			Debug.Log("invalid recipe");
		}

		// decrement the amounts in the inventory
	}

}
