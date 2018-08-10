using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card {

	int value;
	int colourIndex;
	Colour colour;

	public Card(int val, int cIndex){
		value = val;
		// SET colour by enum later
		colourIndex = cIndex;
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

	public int getColourIndex(){
		return colourIndex;
	}

	public void setColourIndex(int index){
		colourIndex = index;
	}
}

public enum Colour {
	Grey,
	Brown,
	Blue,
	Green,
	Red,
	Orange,
	Yellow,
	Pink,
	Purple,
	Glitch
}