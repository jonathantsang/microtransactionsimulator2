using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The inventory "squares" in the lab
public class LabPageClick : MonoBehaviour {

	int id = 0;
	LabPageSelectedController LPSC;

	// Use this for initialization
	void Start () {
		LPSC = GameObject.FindGameObjectWithTag ("SelectedController").GetComponent<LabPageSelectedController> ();

	}

	void OnMouseDown(){
		LPSC.SelectItem (id);
	}

	public void setID(int i){
		id = i;
	}
}
