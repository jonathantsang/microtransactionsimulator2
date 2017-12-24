using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonClick : MonoBehaviour {

	private int shopIndex;
	private int price;

	ShopController SC;
	InventoryController IC;

	// Use this for initialization
	void Start () {
		SC = GameObject.FindGameObjectWithTag ("ShopController").GetComponent<ShopController> ();
		IC = GameObject.FindGameObjectWithTag ("InventoryController").GetComponent<InventoryController> ();

		Button btn = GetComponent<Button> ();
		btn.onClick.AddListener (ClickUpgrade);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ClickUpgrade(){
		// If has enough money
		if(IC.getCurrency() >= price){
			Debug.Log ("bought");
			SC.Unlock(shopIndex);
			// Destroy the object so it can't be bought again
		} else {
			Debug.Log ("not enough money");
		}
	}

	public void setIndexAndPrice(int i, int p){
		shopIndex = i;
		price = p;
	}
}
