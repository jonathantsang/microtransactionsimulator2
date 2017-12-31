using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDirectoryController : MonoBehaviour {

	public static ItemDirectoryController instance;

	public Sprite one, two, three, four, five, six, seven, eight, nine, ten;
	public Sprite eleven, twelve, thirteen, fourteen, fifteen, sixteen, seventeen, eighteen, nineteen, twenty;
	public Sprite twentyone, twentytwo, twentythree, twentyfour, twentyfive, twentysix, twentyseven, twentyeigth, twentynine, thirty;
	public Sprite thirtyone, thirtytwo, thirtythree, thirtyfour, thirtyfive, thirtysix, thirtyseven, thirtyeight, thirtynine, fourty;
	public Sprite fourtyone, fourtytwo, fourtythree, fourtyfour, fourtyfive, fourtysix, fourtyseven, fourtyeight, fourtynine, fifty;
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
			{30, new Item(30, "Earth", "Home", "common")},
			{31, new Item(31, "VR Helmet", "The future is near", "common")},
			{32, new Item(32, "Crab", "Fruits of the sea", "common")},
			{33, new Item(33, "Crowbar", "Opening crates", "common")},
			{34, new Item(34, "Gorilla", "King of the Kongs", "common")},
			{35, new Item(35, "Sniper", "BOOM", "common")},
			{36, new Item(36, "RNG", "Luck based", "common")},
			{37, new Item(37, "Spy", "Secret intel", "common")},
			{38, new Item(38, "Magnifying Glass", "Closer", "common")},
			{39, new Item(39, "Shark Tank", "10% stake", "common")},
			{40, new Item(40, "Famous Painting", "Art", "common")},
			{41, new Item(41, "Violin", "Musical", "common")},
			{42, new Item(42, "Contemporary Art", "Exquisite taste", "common")},
			{43, new Item(43, "Baseball Bat", "Home run", "common")},
			{44, new Item(44, "Pencil", "Doodle bob", "common")},
			{45, new Item(45, "Cake", "Let them eat", "common")},
			{46, new Item(46, "Corrupted Data", "o1aD2IW68", "common")},
			{47, new Item(47, "Clock", "It's 1:04AM", "common")},
			{48, new Item(48, "Ghost", "Spooky", "common")},
			{49, new Item(49, "Chocolate", "Tasty", "common")},
			{50, new Item(50, "Snow", "It's cold", "common")},
		};
		// Indexing starts at 1, so put one twice
		Sprites = new List<Sprite> () {one, one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve, thirteen, fourteen, fifteen, sixteen, seventeen, eighteen, nineteen, twenty,
			twentyone, twentytwo, twentythree, twentyfour, twentyfive, twentysix, twentyseven, twentyeigth, twentynine, thirty,
			thirtyone, thirtytwo, thirtythree, thirtyfour, thirtyfive, thirtysix, thirtyseven, thirtyeight, thirtynine, fourty,
			fourtyone, fourtytwo, fourtythree, fourtyfour, fourtyfive, fourtysix, fourtyseven, fourtyeight, fourtynine, fifty
		};
	}

	public Item getItem(int i){
		return directory [i];
	}

	public Sprite getSprite(int i){
		return Sprites [i];
	}

	public string getName(int i){
		return directory [i].getName ();
	}

}
