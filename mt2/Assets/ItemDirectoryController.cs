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
			{1, new Item(1, "Crate", "Early rng gambling")},
			{2, new Item(2, "Key", "Used to open crates")},
			{3, new Item(3, "Garbage Can", "Worth 0.03")},
			{4, new Item(4, "Hat", "Worth 0.33")},
			{5, new Item(5, "Coin", "Spare change")},
			{6, new Item(6, "Fire", "Prometheus gift")},
			{7, new Item(7, "Code", "What this is made of")},
			{8, new Item(8, "Refined Metal", "Hmm yes quite")},
			{9, new Item(9, "Season Pass", "$60 for already made content!")},
			{10, new Item(10, "Preordered Game", "Review embargo")}
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
