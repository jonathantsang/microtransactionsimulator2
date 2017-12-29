using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeButton : MonoBehaviour {

	public GameObject Popup;

	InventoryController IC;
	RecipeDirectoryController RDC;
	LabController LC;
	LabPageItemSlotClick SlotOne;
	LabPageItemSlotClick SlotTwo;

	// Use this for initialization
	void Start () {
		// Linking
		RDC = GameObject.FindGameObjectWithTag("RecipeDirectoryController").GetComponent<RecipeDirectoryController>();
		IC = GameObject.FindGameObjectWithTag ("InventoryController").GetComponent<InventoryController> ();
		LC = GameObject.FindGameObjectWithTag ("LabController").GetComponent<LabController> ();

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
			// valid recipe, create popup textbox of recipe
			Instantiate(Popup, new Vector3(), Quaternion.identity);
			// Update each recipe with sprite later
			// Popup.transform.GetChild (1).GetComponent<SpriteRenderer> ().sprite = RDC.getSprite (check);
			Popup.transform.GetChild (2).GetComponent<TextMesh> ().text = RDC.getName (check);
		} else {
			// invalid recipe
			Debug.Log("invalid recipe");
		}

		// decrement the amounts in the inventory
		IC.RemoveFromInventory (i1);
		IC.RemoveFromInventory (i2);

		// Update the text on the LabInventory
		LC.UpdateCountText (i1);
		LC.UpdateCountText (i2);
	}

}
