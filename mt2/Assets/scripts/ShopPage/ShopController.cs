using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Deals with SETTING UP the shop page, displaying and not displaying already bought
public class ShopController : MonoBehaviour {

	ShopUnlocked SU;
	ShopCurrency SC;
	InventoryController IC;
	List<GameObject> UpgradeList;

	// Shop Upgrades
	// 1-3 Opens 1 more crate
	// 4 unlocks casino scog lotto
	// 5 luck tweaked
	// 6 retro game
	// 7 unlocks player 1 z ground
	// 8 achievement (cali or bust)
	// 9 secondary shop

	// Use this for initialization
	void Start () {
		UpgradeList = new List<GameObject> ();
		SU = GameObject.FindGameObjectWithTag ("ShopUnlocked").GetComponent<ShopUnlocked> ();
		SC = GameObject.FindGameObjectWithTag ("Currency").GetComponent<ShopCurrency> ();
		IC = GameObject.FindGameObjectWithTag ("InventoryController").GetComponent<InventoryController> ();
		SetupUpgrades();
	}

	void SetupUpgrades(){
		// Find Upgrades
		GameObject Upgrades = GameObject.FindGameObjectWithTag ("Upgrades").gameObject;
		// prices
		List<int> prices = new List<int> {99, 499, 999, 299, 399, 109, 394, 808, 2048};
		// DestroyAlreadyUpgraded
		for (int i = 0; i < Upgrades.transform.childCount; i++) {
			// set index and price
			UpgradeList.Add (Upgrades.transform.GetChild (i).gameObject);
			Upgrades.transform.GetChild(i).transform.GetChild(0).GetComponent<ShopButtonClick> ().setIndexAndPrice (i, prices[i]);
			if (SU.CheckUpgrades(i) == 1) {
				Debug.Log ("already bought " + i);
				Destroy (UpgradeList[i]);
			}
		}
	}

	public void Unlock(int i){
		// Store Unlocked marks it
		SU.Unlock (i);
		// Subtrack price from currency
		List<int> prices = new List<int> {99, 499, 999, 299, 399, 109, 394, 808, 2048};
		int price = prices [i];
		IC.DecreaseCurrency (price);
		// Decrease Currency Text
		SC.UpdateText();
		// Destroy the upgrade in shopcontroller
		Destroy (UpgradeList [i]);
	}
}
