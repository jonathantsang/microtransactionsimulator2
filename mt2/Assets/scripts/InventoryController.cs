using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Persistent throughout all games
public class InventoryController : MonoBehaviour {

	public static InventoryController instance;

	// each item is denoted as an int for id
	private List<int> inventory;
	private Dictionary<int, int> collected; // Used for inventory page that lets you know what you have seen

	// data for storage
	private int NumberOpened = 0; // How many crates opened
	private int Currency = 300; // How much currency they have
	private int OpenCount = 3; // How many to open at once

	// Use this for initialization
	void Start () {
		// Singleton Behaviour
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
		DontDestroyOnLoad(gameObject);

		inventory = new List<int> ();
		collected = new Dictionary<int, int> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addToInventory(int i){
		inventory.Add (i);
		if (collected.ContainsKey (i)) {
			collected [i] += 1;
		} else {
			collected [i] = 1;
		}
	}

	public int HowManyToOpen(){
		return OpenCount;
	}

	public List<int> getInventory(){
		return inventory;
	}

	public Dictionary<int, int> getCollected(){
		return collected;
	}

	public bool checkCollected(int i){
		return collected.ContainsKey(i) && collected[i] >= 1;
	}

	public int getCollectedAmount(int i){
		return collected [i];
	}

	public int getCurrency(){
		return Currency;
	}

	public int getNumberOpened(){
		return NumberOpened;
	}
}
