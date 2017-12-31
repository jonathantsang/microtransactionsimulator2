using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletController : MonoBehaviour {

	int amount  = 0;
	int counter = 0;
	InventoryController IC;

	// Use this for initialization
	void Start () {
		// Linking
		IC = GameObject.FindGameObjectWithTag("InventoryController").GetComponent<InventoryController>();

		amount = transform.childCount;
		counter = amount;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int getAmount(){
		return counter;
	}

	public void setAmount(int a){
		counter = a;
	}

	public void DecrementAmount(){
		counter--;
		// all pellets gone
		if (counter == 0) {
			IC.CompleteRetro ();
		}
	}
}
