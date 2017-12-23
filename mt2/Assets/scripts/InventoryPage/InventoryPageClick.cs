using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPageClick : MonoBehaviour {

	int id;
	InventoryPageSelectedController IPSC;
	GameObject selected;

	// Use this for initialization
	void Start () {
		IPSC = GameObject.FindGameObjectWithTag ("InventoryPageSelectedController").GetComponent<InventoryPageSelectedController> ();
		// turn off selected
		selected = transform.GetChild(0).gameObject;
		selected.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		IPSC.SelectItem (id);
	}

	public void setID(int i){
		id = i;
	}

	public void Select(){
		selected.SetActive (true);
	}

	public void Deselect(){
		selected.SetActive (false);
	}
}
