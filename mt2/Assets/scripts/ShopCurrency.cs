using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCurrency : MonoBehaviour {

	InventoryController IC;
	Text currency;

	// Use this for initialization
	void Start () {
		IC = GameObject.FindGameObjectWithTag ("InventoryController").GetComponent<InventoryController> ();
		currency = GetComponent<Text> ();
		// Loads current currency into the text
		int amount = IC.getCurrency();
		currency.text = amount.ToString () + "C";
	}
	
	// Update is called once per frame
	void Update () {
		if (IC) {
			UpdateText ();
		}
	}

	public void UpdateText(){
		// Loads current currency into the text
		int amount = IC.getCurrency();
		currency.text = amount.ToString () + "C";
	}


}
