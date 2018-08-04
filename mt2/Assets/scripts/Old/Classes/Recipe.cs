using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe {

	int id;
	// Merging can take the ingredients in any order, so it can be swapped
	int ingredient1;
	int ingredient2;
	string name;

	public Recipe(int num, int i1, int i2, string n){
		id = num;
		ingredient1 = i1;
		ingredient2 = i2;
		name = n;
	}

	// Checks if i1 and i2 are possible from ingredient1 and ingredient2
	public bool CheckRecipe(int i1, int i2){
		if (i1 == ingredient1) {
			if (i2 == ingredient2) {
				return true;
			}
			return false;
		} else if (i2 == ingredient1) {
			if (i1 == ingredient2) {
				return true;
			}
			return false;
		}
		return false;
	}

	public int getID(){
		return id;
	}

	public string getName(){
		return name;
	}

}
