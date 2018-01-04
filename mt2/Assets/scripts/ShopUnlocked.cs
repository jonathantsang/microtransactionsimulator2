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
		shopUnlockedList = new List<int> () { 0,0,0,0,0,0,0,0,0,0};

		// Linking
		IC = GameObject.FindGameObjectWithTag("InventoryController").GetComponent<InventoryController>();

		// Shop Upgrades
		// 0-2 Opens 1 more crate
		// 3 unlocks casino scog lotto
		// 4 luck tweaked
		// 5 retro game
		// 6 unlocks player 1 z ground
		// 7 achievement (cali or bust)
		// 8 secondary shop

		int numUpgrades = 9; // TODO increase
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
			// should show up in the worlds
		} else if (i == 4) {
			// luck or not really
		} else if (i == 5) {
			// retro game
			// should show up in the worlds
		} else if (i == 6) {
			// player 1 z ground
		} else if (i == 7) {
			// achievement
			// duty of honour expansion
		} else if (i == 8) {
			// second shop
		} 
	}

	public int CheckUpgrades(int i){
		return shopUnlockedList [i];
	}
}
