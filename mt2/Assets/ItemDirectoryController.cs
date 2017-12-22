using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDirectoryController : MonoBehaviour {

	public static ItemDirectoryController instance;

	public Sprite one, two, three, four, five, six, seven, eight, nine, ten;

	Dictionary<int, Item> directory;
	List<Sprite> Sprites;

	// Use this for initialization
	void Start () {
		// Singleton Behaviour
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);    
		DontDestroyOnLoad (gameObject);
	
		directory = new Dictionary<int, Item> () {
			{1, new Item(1, "Crate", "a locked door to early rng gambling")},
			{2, new Item(2, "Key", "can be used to open crates. Just not these ones")},
			{3, new Item(3, "Garbage Can", "when you pay $2.50 for a key and get $0.03 back")},
			{4, new Item(4, "Hat", "when you pay $2.50 for a key and get $0.33 back")},
			{5, new Item(5, "Coin", "spare change")},
			{6, new Item(6, "Fire", "prometheus gift")},
			{7, new Item(7, "Code", "what this is made of")},
			{8, new Item(8, "Refined Metal", "hmm yes quite")},
			{9, new Item(9, "Season Pass", "Sweet! Only $60 for already made content!")},
			{10, new Item(10, "Preordered Game", "There is a review embargo up, but I trust the developers this time.")}
		};
		// Indexing starts at 1, so put one twice
		Sprites = new List<Sprite> () {one, one, two, three, four, five, six, seven, eight, nine, ten};
	}

	public Item getItem(int i){
		return directory [i];
	}

	public Sprite getSprite(int i){
		return Sprites [i];
	}

}
