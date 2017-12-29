using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Persistent throughout all games
public class InventoryController : MonoBehaviour {

	public static InventoryController instance;

	// each item is denoted as an int for id
	private List<int> inventory;
	private Dictionary<int, int> collected; // Used for inventory page that lets you know what you have seen
	private Dictionary<int, int> recipesUnlocked; // Recipes unlocked

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

		// TODO TESTING
		recipesUnlocked = new Dictionary<int, int>();
		inventory = new List<int> () {2, 3, 6, 8, 9, 10, 16};
		collected = new Dictionary<int, int> () {{2, 3}, {4, 1}, {6, 2}, {9, 0}, {10, 1}, {11, 2}, {18, 2}};

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddToInventory(int i){
		inventory.Add (i);
		if (collected.ContainsKey (i)) {
			collected [i] += 1;
		} else {
			collected [i] = 1;
		}
	}

	public void RemoveFromInventory(int i){
		if (collected.ContainsKey (i)) {
			collected [i] -= 1;
		}
	}

	public void AddToRecipes(int i){
		if (recipesUnlocked.ContainsKey (i)) {
			recipesUnlocked [i] += 1;
		} else {
			recipesUnlocked [i] = 1;
		}
	}

	public void DecreaseCurrency(int i){
		Currency -= i;
	}

	public int getOpenCount(){
		return OpenCount;
	}

	public List<int> getInventory(){
		return inventory;
	}

	public Dictionary<int, int> getCollected(){
		return collected;
	}

	public bool checkCollected(int i){
		// ONLY checks it has it, not if it is more than 0 amount
		return collected.ContainsKey (i);
	}

	public int getCollectedAmount(int i){
		// If it is not in it
		if (!checkCollected (i)) {
			return -1;
		}
		return collected [i];
	}

	public int getCurrency(){
		return Currency;
	}

	public int getNumberOpened(){
		return NumberOpened;
	}
}
