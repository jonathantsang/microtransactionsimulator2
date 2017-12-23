using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BF_Card : MonoBehaviour {
	Animation animation;
	Animator animator;
	GameObject Front;
	GameObject Opened;
	Item CardItem;

	private InventoryController IC;

	// Use this for initialization
	void Start () {
		// links first
		IC = GameObject.FindGameObjectWithTag("InventoryController").GetComponent<InventoryController>();

		Front = gameObject;
		Opened = transform.parent.transform.GetChild (1).gameObject; // Opened is sibling of card
		animation = GetComponent<Animation> ();
		animator = GetComponent<Animator> ();
		DisableOpened (); // Beginning disable opened
	}

	// Manually click it
	void OnMouseDown()
	{
		openCard ();
	}

	void DisableFront(){
		Front.SetActive (false);
		Opened.SetActive (true);
	}

	void DisableOpened(){
		Front.SetActive (true);
		Opened.SetActive (false);
	}

	void openCard(){
		// Set rotation animation
		Debug.Log("flip card");
		animator.SetTrigger ("Flip");
		// wait for rotation before turning front off
		StartCoroutine(Wait(20)); // 20 * 0.1 is 2 seconds 
		// add item to the inventory
		IC.addToInventory(CardItem.getID());
	}

	IEnumerator Wait(float time){
		float counter = 0f;
		while(counter < time){
			yield return new WaitForSeconds(0.1f);
			counter += 1;
		}
		DisableFront ();
	}

	public void setItem(Item item){
		CardItem = item;
	}
		
}
