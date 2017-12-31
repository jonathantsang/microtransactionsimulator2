using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Persistent throughout all games
public class InventoryController : MonoBehaviour {

	public static InventoryController instance;

	// each item is denoted as an int for id
	private List<int> Inventory;
	private Dictionary<int, int> Collected; // Used for inventory page that lets you know what you have seen
	private Dictionary<int, int> RecipesUnlocked; // Recipes unlocked
	private List<int> Stats; // Keeps track of boolean things:
	// 0 
	// 1
	// 2 RetroCompleted

	// data for storage
	private int NumberOpened = 0; // How many crates opened
	private int Currency = 10; // How much currency they have
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
		Stats = new List<int>() {0, 0, 0};
		RecipesUnlocked = new Dictionary<int, int>();
		Inventory = new List<int> () {2, 3, 6, 8, 9, 10, 16};
		Collected = new Dictionary<int, int> () {{2, 3}, {4, 1}, {6, 2}, {9, 0}, {10, 1}, {11, 2}, {18, 2}};

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddToInventory(int i){
		Inventory.Add (i);
		if (Collected.ContainsKey (i)) {
			Collected [i] += 1;
		} else {
			Collected [i] = 1;
		}
	}

	public void RemoveFromInventory(int i){
		if (Collected.ContainsKey (i) && Collected[i] > 0) {
			Collected [i] -= 1;
		}
	}

	public void AddToRecipes(int i){
		if (RecipesUnlocked.ContainsKey (i)) {
			RecipesUnlocked [i] += 1;
		} else {
			RecipesUnlocked [i] = 1;
		}
	}

	public bool CheckNewRecipe(int i){
		if (RecipesUnlocked.ContainsKey (i)) {
			return false;
		} else {
			return true;
		}
	}

	public bool CheckRecipe(int i){
		if (RecipesUnlocked.ContainsKey (i)) {
			if (RecipesUnlocked [i] >= 1) {
				return true;
			}
			return false;
		} else {
			return false;
		}
	}

	public void DecreaseCurrency(int amt){
		Currency -= amt;
	}

	public void IncreaseCurrency(int amt){
		Currency += amt;
	}

	public int getOpenCount(){
		return OpenCount;
	}

	public Dictionary<int, int> getCollected(){
		return Collected;
	}

	public bool checkCollected(int i){
		// ONLY checks it has it, not if it is more than 0 amount
		return Collected.ContainsKey (i);
	}

	public int getCollectedAmount(int i){
		// If it is not in it
		if (!checkCollected (i)) {
			return -1;
		}
		return Collected [i];
	}

	public int getCurrency(){
		return Currency;
	}

	public int getNumberOpened(){
		return NumberOpened;
	}

	// USED FOR SHOP UPGRADES
	public void IncrementOpenCount(){
		OpenCount++;
	}

	public void CompleteRetro(){
		Stats [2]++; // Done
	}
}
