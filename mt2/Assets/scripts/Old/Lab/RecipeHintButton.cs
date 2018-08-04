using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeHintButton : MonoBehaviour {

	public GameObject RecipePopup;
	RecipeDirectoryController RDC;
	InventoryController IC;

	// Use this for initialization
	void Start () {
		// Linking
		RDC = GameObject.FindGameObjectWithTag("RecipeDirectoryController").GetComponent<RecipeDirectoryController>();
		IC = GameObject.FindGameObjectWithTag("InventoryController").GetComponent<InventoryController>();

		Button btn = GetComponent<Button> ();
		btn.onClick.AddListener (ShowRecipes);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ShowRecipes(){
		GameObject RecipesListed = Instantiate (RecipePopup, new Vector3 (), Quaternion.identity);
		// For 28 recipes, two columns of 14
		GameObject column1 = RecipesListed.transform.GetChild(1).gameObject;
		GameObject column2 = RecipesListed.transform.GetChild(2).gameObject;
		// Marks complete as 2, white, 1 for beside a complete but not itself complete in red
		List<int> col1 = new List<int>();
		List<int> col2 = new List<int>();
		for (int i = 0; i < column1.transform.childCount; i++) {
			if (IC.CheckRecipe (i)) {
				col1.Add (2);
			} else if ((i - 1 >= 0 && IC.CheckRecipe (i - 1)) || (i + 1 < column1.transform.childCount && IC.CheckRecipe (i + 1))) {
				col1.Add (1);
			} else {
				col1.Add (0);
			}
		}
		for (int i = 0; i < column2.transform.childCount; i++) {
			int j = i + 14;
			if (IC.CheckRecipe (j)) {
				col2.Add (2);
			} else if ((i - 1 >= 0 && IC.CheckRecipe (j - 1)) || (i + 1 < column2.transform.childCount && IC.CheckRecipe (j + 1))) {
				col2.Add (1);
			} else {
				col2.Add (0);
			}
		}
		// Go through col1 and col2
		for (int i = 0; i < col1.Count; i++){
			if (col1 [i] == 2) {
				// White
				column1.transform.GetChild (i).GetComponent<TextMesh> ().text = i + " " + RDC.getRecipeName(i);
			} else if (col1 [i] == 1) {
				column1.transform.GetChild (i).GetComponent<TextMesh> ().color = new Color (1, 0, 0); // red
				column1.transform.GetChild (i).GetComponent<TextMesh> ().text = i + " " + RDC.getRecipeName(i);
			} else {
				column1.transform.GetChild (i).GetComponent<TextMesh> ().text = i + " " + "???";
			}
		}
		for (int i = 0; i < col2.Count; i++) {
			if (col2 [i] == 2) {
				// White
				int j = i + 14;
				column2.transform.GetChild (i).GetComponent<TextMesh> ().text = j + " " + RDC.getRecipeName(i);
			} else if (col2 [i] == 1) {
				int j = i + 14;
				column2.transform.GetChild (i).GetComponent<TextMesh> ().color = new Color (1, 0, 0); // red
				column2.transform.GetChild (i).GetComponent<TextMesh> ().text = j + " " + RDC.getRecipeName(i);
			} else {
				int j = i + 14;
				column2.transform.GetChild (i).GetComponent<TextMesh> ().text = j + " " + "???";
			}
		}
	}
}
