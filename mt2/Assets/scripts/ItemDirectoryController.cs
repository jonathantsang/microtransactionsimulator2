using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDirectoryController : MonoBehaviour {

	public static ItemDirectoryController instance;

	public Sprite one, two, three, four, five, six, seven, eight, nine, ten;
	public Sprite eleven, twelve, thirteen, fourteen, fifteen, sixteen, seventeen, eighteen, nineteen, twenty;
	public Sprite twentyone, twentytwo, twentythree, twentyfour, twentyfive, twentysix, twentyseven, twentyeigth, twentynine, thirty;

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
			{1, new Item(1, "Crate", "Early RNG gambling", "common")},
			{2, new Item(2, "Key", "Used to open crates", "common")},
			{3, new Item(3, "Garbage Can", "Worth 0.03", "common")},
			{4, new Item(4, "Hat", "Worth 0.33", "common")},
			{5, new Item(5, "Coin", "Spare change", "common")},
			{6, new Item(6, "Fire", "Prometheus gift", "common")},
			{7, new Item(7, "Code", "What this is made of", "common")},
			{8, new Item(8, "Refined Metal", "Hmm yes quite", "common")},
			{9, new Item(9, "Season Pass", "Already made content!", "common")},
			{10, new Item(10, "Preordered Game", "Review embargo", "common")},
			{11, new Item(11, "Net Neutrality", "lost the battle and the war", "common")},
			{12, new Item(12, "Major League Chips", "x2 exp bonus", "common")},
			{13, new Item(13, "Pair of socks", "A spare", "common")},
			{14, new Item(14, "Apple", "iEat", "common")},
			{15, new Item(15, "Chicken", "Finger-licking", "common")},
			{16, new Item(16, "Ice Cube", "from the gang called", "common")},
			{17, new Item(17, "Soldier", "Generic shooter", "common")},
			{18, new Item(18, "Nuke", "Kaboom", "common")},
			{19, new Item(19, "Fakecoin", "Fake money", "common")},
			{20, new Item(20, "Fakecontract", "Fake smart contract", "common")},
			{21, new Item(21, "Major League Beverage", "Gulp gulp", "common")},
			{22, new Item(22, "Friend's Credit Card", "Free money", "common")},
			{23, new Item(23, "Casino chips", "Circular money", "common")},
			{24, new Item(24, "Burger", "Yummy", "common")},
			{25, new Item(25, "Fries", "Fried", "common")},
			{26, new Item(26, "Streaming Site", "$12 a month", "common")},
			{27, new Item(27, "Fidget Spinner", "Keeping it hip", "common")},
			{28, new Item(28, "Sun", "Warm circle", "common")},
			{29, new Item(29, "Moon", "Cheesey", "common")},
			{30, new Item(30, "Earth", "Home", "common")}
		};
		// Indexing starts at 1, so put one twice
		Sprites = new List<Sprite> () {one, one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve, thirteen, fourteen, fifteen, sixteen, seventeen, eighteen, nineteen, twenty,
			twentyone, twentytwo, twentythree, twentyfour, twentyfive, twentysix, twentyseven, twentyeigth, twentynine, thirty};
	}

	public Item getItem(int i){
		return directory [i];
	}

	public Sprite getSprite(int i){
		return Sprites [i];
	}

}
