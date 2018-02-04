using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour {

	InventoryController IC;
	ShopUnlocked SU;

	// Use this for initialization
	void Start () {
		IC = GameObject.FindGameObjectWithTag ("InventoryController").GetComponent<InventoryController> ();
		SU = GameObject.FindGameObjectWithTag ("ShopUnlocked").GetComponent<ShopUnlocked> ();
		Save ();
		Load ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Save(){
		print ("saved");
		// save hardcoded value
		SaveLoadManager.SaveData (5893);
	}

	public void Load(){
		SaveData loadedStats = SaveLoadManager.LoadData ();

		// Load from stats
		print(loadedStats.Currency);
		IC.LoadInventory (loadedStats.Currency);

		// Loads data
		print(loadedStats);
	}
}
