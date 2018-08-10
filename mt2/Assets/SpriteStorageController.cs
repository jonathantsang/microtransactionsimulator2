using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteStorageController : MonoBehaviour {

	public Sprite card1;
	public Sprite card2;
	public Sprite card3;
	public Sprite card4;
	public Sprite card5;
	public Sprite card6;
	public Sprite card7;
	public Sprite card8;
	public Sprite card9;
	public Sprite card10;

	Sprite[] cardColours = new Sprite[10];

	// Use this for initialization
	void Start () {
		cardColours [0] = card1;
		cardColours [1] = card2;
		cardColours [2] = card3;
		cardColours [3] = card4;
		cardColours [4] = card5;
		cardColours [5] = card6;
		cardColours [6] = card7;
		cardColours [7] = card8;
		cardColours [8] = card9;
		cardColours [9] = card10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Sprite getCardColour(int i){
		if (i < 0 || i > cardColours.Length - 1) {
			return cardColours [0];
		}
		return cardColours [i];
	}
}
