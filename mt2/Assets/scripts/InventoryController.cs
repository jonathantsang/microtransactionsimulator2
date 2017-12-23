using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Persistent throughout all games
public class InventoryController : MonoBehaviour {

	public static InventoryController instance;

	// each item is denoted as an int for id
	private List<int> inventory;

	private int OpenCount = 3; // How many to open at once

	// Use this for initialization
	void Start () {
		// Singleton Behaviour
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
		DontDestroyOnLoad(gameObject);

		inventory = new List<int> () { 2, 3, 4, 9 };
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addToInventory(int i){
		inventory.Add (i);
	}

	public int HowManyToOpen(){
		return OpenCount;
	}

	public List<int> getInventory(){
		return inventory;
	}
}
