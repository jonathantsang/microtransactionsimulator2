using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabPageSelectedController : MonoBehaviour {

	// Person clicks on a space in the equation, last one pressed it puts the item there
	int previousID;
	int previousSlot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SelectItem(int id){
		Debug.Log ("selected item " + id);
		// do stuff
		previousID = id;
	}

	public void SelectSlot(int id){
		Debug.Log ("selected item slot " + id);
		if (id == -1) {
			return;
		}
		// do stuff
		previousSlot = id;
	}
}
