using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabPageSelectedController : MonoBehaviour {

	// Person clicks on a space in the equation, last one pressed it puts the item there
	int previousID = -1;
	int previousSlot = -1;
	LabController LC;

	// Use this for initialization
	void Start () {
		LC = GameObject.FindGameObjectWithTag ("LabController").GetComponent<LabController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SelectItem(int id){
		if (id == -1) {
			return;
		}
		Debug.Log ("selected item " + id);

		// selected slot first
		if (previousSlot != -1) {
			// input the slot as previousID
			Debug.Log ("slot " + previousSlot + " puts " + id);
			LC.InputSlot (previousSlot, id);
			clear ();
		} else {
			previousID = id;
		}

	}

	public void SelectSlot(int id){
		Debug.Log ("selected item slot " + id);
		if (id == -1) {
			return;
		}
		// do stuff

		// selected item first
		if (previousID != -1) {
			// input the slot as previousID
			Debug.Log ("slot " + id + " puts " + previousID);
			LC.InputSlot (id, previousID);
			clear ();
		} else {
			previousSlot = id;
		}

	}

	void clear(){
		previousID = -1;
		previousSlot = -1;
	}
}
