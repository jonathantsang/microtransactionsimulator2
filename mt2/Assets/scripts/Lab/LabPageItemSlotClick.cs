using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabPageItemSlotClick : MonoBehaviour {

	int id;
	LabPageSelectedController LPSC;

	// Use this for initialization
	void Start () {
		LPSC = GameObject.FindGameObjectWithTag ("SelectedController").GetComponent<LabPageSelectedController> ();

	}

	void OnMouseDown(){
		LPSC.SelectSlot (id);
	}

	public void setID(int i){
		id = i;
	}
}
