using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUnlocked : MonoBehaviour {

	public static ShopUnlocked instance;

	InventoryController IC;
	List<int> shopUnlockedList;

	// Use this for initialization
	void Start () {
		// Singleton Behaviour
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
		DontDestroyOnLoad(gameObject);
		Debug.Log ("shop start");
		shopUnlockedList = new List<int> ();

		int numUpgrades = 9; // TODO increase
		for (int i = 0; i < numUpgrades; i++) {
			shopUnlockedList.Add (0);
		}
	}

	public void Unlock(int i){
		shopUnlockedList [i] = 1;
	}

	public int CheckUpgrades(int i){
		return shopUnlockedList [i];
	}
}
