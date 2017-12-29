using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDirectoryController : MonoBehaviour {

	List<Recipe> Recipes;

	// Use this for initialization
	void Start () {
		Recipes = new List<Recipe> () {
			new Recipe(1,10,18, "War never changes...")
		};
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Checks if it is a recipe, and returns the id or -1 if it fails
	public int CheckRecipes(int i1, int i2){
		// Go through each recipe and check
		for(int i = 0; i < Recipes.Count; i++){
			if (Recipes [i].CheckRecipe (i1, i2)) {
				return i;
			}
		}
		return -1;
	}
}
