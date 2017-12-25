using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopController : MonoBehaviour {

	ShopUnlocked SU;
	List<GameObject> UpgradeList;

	// Use this for initialization
	void Start () {
		UpgradeList = new List<GameObject> ();
		SU = GameObject.FindGameObjectWithTag ("ShopUnlocked").GetComponent<ShopUnlocked> (); 
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

	public void Bought(int i){
		
	}

	public void Unlock(int i){
		// Store Unlocked marks it
		SU.Unlock (i);
		// Subtrack price from currency

		// Destroy the upgrade in shopcontroller
		Destroy (UpgradeList [i]);
	}
}
