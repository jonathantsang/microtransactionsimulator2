using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCollider : MonoBehaviour {

	int value;
	int colourIndex;

	bool flipped;
	GameObject cardBack;

	InventoryController IC;

	// Use this for initialization
	void Start () {
		flipped = false;
		setCardBack ();

		IC = GameObject.FindGameObjectWithTag ("InventoryController").GetComponent<InventoryController> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseOver()
	{
		//If your mouse hovers over the GameObject with the script attached, output this message
		// Debug.Log("Mouse is over GameObject.");
		// Highlight colour
	}

	void OnMouseDown()
	{
		if (!flipped) {
			disableCardBack ();
			// Add to the inventory
			IC.addCard(new Card(value, colourIndex));
			print ("added " + value + " and colour index " + colourIndex);
		}

	}

	void disableCardBack(){
		flipped = true;
		cardBack.SetActive (false);
	}

	public void setFlipped(bool flipped){
		this.flipped = flipped;
	}

	public void setCardBackState(bool state){
		cardBack.SetActive (state);
	}

	void setCardBack(){
		cardBack = transform.GetChild (2).gameObject;
	}

	public void setValueAndColourIndex(int value, int colourIndex){
		this.value = value;
		this.colourIndex = colourIndex;
	}
}
