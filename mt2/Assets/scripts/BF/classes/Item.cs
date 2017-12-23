using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {

	public Item(int i, string s, string d, string r){
		id = i;
		name = s;
		description = d;
		rarity = r;
	}

	int id;
	string name;
	string description;
	string rarity;

	public int getID(){
		return id;
	}

	public string getName(){
		return name;
	}

	public string getDescription(){
		return description;
	}

	public string getRarity(){
		return rarity;
	}
}
