using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card {

	int value;
	Colour colour;

	public Card(int val){
		value = val;
		// SET colour by enum later
	}

	public int getValue(){
		return value;
	}

	public void setValue(int value){
		this.value = value;
	}

	public Colour getColour(){
		return colour;
	}

	public void setColour(Colour colour){
		this.colour = colour;
	}
}

public	enum Colour {
	White,
	Blue
}