using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {

	public Item(int i, string s, string d){
		id = i;
		name = s;
	}

	int id;
	string name;
	string description;

	public int getID(){
		return id;
	}

	public string getName(){
		return name;
	}

	public string getDescription(){
		return description;
	}
}
