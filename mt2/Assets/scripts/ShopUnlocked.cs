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

		// Based on the index, it does different upgrades
		if (i == 0) {
			IC.IncrementOpenCount ();
		} else if (i == 1) {
			IC.IncrementOpenCount ();
		} else if (i == 2) {
			IC.IncrementOpenCount ();
		} else if (i == 3) {
			// unlock scog lotto
		} else if (i == 4) {
			// luck or not really
			// duty of honour expansion
		} else if (i == 5) {
			// retro game
		} else if (i == 6) {
			// player 1 z ground
		} else if (i == 7) {
			// achievement
		} else if (i == 8) {
			// second shop
		} 
	}

	public int CheckUpgrades(int i){
		return shopUnlockedList [i];
	}
}
