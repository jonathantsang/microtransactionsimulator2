using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeButton : MonoBehaviour {

	public GameObject Popup;
	public Sprite Locked;

	InventoryController IC;
	RecipeDirectoryController RDC;
	LabController LC;
	ShopCurrency SC;

	GameObject SlotOne;
	GameObject SlotTwo;

	// Use this for initialization
	void Start () {
		// Linking
		RDC = GameObject.FindGameObjectWithTag("RecipeDirectoryController").GetComponent<RecipeDirectoryController>();
		IC = GameObject.FindGameObjectWithTag ("InventoryController").GetComponent<InventoryController> ();
		LC = GameObject.FindGameObjectWithTag ("LabController").GetComponent<LabController> ();
		SC = GameObject.FindGameObjectWithTag ("Currency").GetComponent<ShopCurrency> ();

		SlotOne = GameObject.FindGameObjectWithTag ("RightPanel").transform.GetChild (0).gameObject;
		SlotTwo = GameObject.FindGameObjectWithTag ("RightPanel").transform.GetChild (2).gameObject;

		Button btn = GetComponent<Button> ();
		btn.onClick.AddListener (Merge);
	}

	void Merge(){
		// call RDC to check the slots
		int i1 = SlotOne.transform.GetChild (1).GetComponent<LabPageItemSlotClick> ().getItemID ();
		int i2 = SlotTwo.transform.GetChild (1).GetComponent<LabPageItemSlotClick> ().getItemID ();
		Debug.Log("got " + i1 + " " + i2);

		// Checks if it is a valid recipe
		int check = RDC.CheckRecipes(i1, i2);
		if(check != -1){
			int id = check;
			// Checks if the recipe is already made
			if (!IC.CheckNewRecipe (id)) {
				// Not a new recipe
				Debug.Log ("Already made recipe");
				GameObject obj = Instantiate (Popup, new Vector3 (), Quaternion.identity);
				// Popup.transform.GetChild (1).GetComponent<SpriteRenderer> ().sprite = RDC.getSprite (check);
				// Description
				obj.transform.GetChild (0).GetComponent<TextMesh> ().text = "ERROR";
				obj.transform.GetChild (2).GetComponent<TextMesh> ().text = "Recipe already found";
				obj.transform.GetChild (3).GetComponent<TextMesh> ().text = "You got 0 coins";
				return;
			} else {
				Debug.Log("valid recipe");
				// call recipe done in inventory
				IC.AddToRecipes(id);
				// valid recipe, create popup textbox of recipe
				GameObject obj = Instantiate(Popup, new Vector3(), Quaternion.identity);
				// Update with sprite
				obj.transform.GetChild (1).GetComponent<SpriteRenderer> ().sprite = RDC.getSprite (id);
				// Description
				obj.transform.GetChild (2).GetComponent<TextMesh> ().text = RDC.getRecipeName (id);
				// Currency
				int gain = Random.Range(75,125);
				obj.transform.GetChild (3).GetComponent<TextMesh> ().text = "You got " + gain.ToString() + " coins";
				// Add the currency amount
				IC.IncreaseCurrency(gain);
				// Update the Currency counter in corner
				SC.UpdateText();
			}
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

		// Need to reset SlotOne and SlotTwo itemID
		SlotOne.transform.GetChild (1).GetComponent<LabPageItemSlotClick> ().ResetItemID ();
		SlotTwo.transform.GetChild (1).GetComponent<LabPageItemSlotClick> ().ResetItemID ();
		// Reset the sprites
		SlotOne.transform.GetChild(1).GetComponent<Image>().sprite = Locked;
		SlotTwo.transform.GetChild(1).GetComponent<Image>().sprite = Locked;
		// Reset the names
		SlotOne.transform.GetChild(0).GetComponent<Text>().text = "Locked";
		SlotTwo.transform.GetChild(0).GetComponent<Text>().text = "Locked";
	}
}
