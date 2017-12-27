using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LW_CreateCards : MonoBehaviour {

	public GameObject Card1;
	public GameObject Card2;
	public GameObject Card3;

	GameObject Positions;
	GameObject CardHolder;

	InventoryController IC;
	LW_RNGController RNGC;
	ItemDirectoryController IDC;

	// Use this for initialization
	void Start () {
		IC = GameObject.FindGameObjectWithTag ("InventoryController").GetComponent<InventoryController> ();
		RNGC = GameObject.FindGameObjectWithTag ("RNGController").GetComponent<LW_RNGController> ();
		IDC = GameObject.FindGameObjectWithTag ("ItemDirectoryController").GetComponent<ItemDirectoryController> ();

		Positions = GameObject.FindGameObjectWithTag ("CardPlaces").gameObject;
		CardHolder = GameObject.FindGameObjectWithTag ("CardHolder").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MakeCards(){
		for(int i = 0; i < IC.HowManyToOpen(); i++){
			int choose = Random.Range (0, 3);
			int id;
			if (choose == 0) {
				GameObject CreatedCard = Instantiate (Card1, Positions.transform.GetChild (i).transform.position, Quaternion.identity);
				CreatedCard.transform.SetParent (CardHolder.transform);

				// Image
				SpriteRenderer renderer = CreatedCard.transform.GetChild (1).GetComponent<SpriteRenderer> ();
				// Name
				TextMesh name = CreatedCard.transform.GetChild (2).GetComponent<TextMesh> ();

				// Call rng controller for stuff
				id = RNGC.getRandom ();
				Item item = IDC.getItem (id);

				// change icon
				renderer.sprite = IDC.getSprite (id);

				// change name
				name.text = item.getName ();

				// add to the inventory
				IC.addToInventory (id);
			} else if (choose == 1) {
				GameObject CreatedCard = Instantiate (Card2, Positions.transform.GetChild (i).transform.position, Quaternion.identity);
				CreatedCard.transform.SetParent (CardHolder.transform);

				// Image
				SpriteRenderer renderer = CreatedCard.transform.GetChild (1).GetComponent<SpriteRenderer> ();
				// Name
				TextMesh name = CreatedCard.transform.GetChild (2).GetComponent<TextMesh> ();

				// Call rng controller for stuff
				id = RNGC.getRandom ();
				Item item = IDC.getItem (id);

				// change icon
				renderer.sprite = IDC.getSprite (id);

				// change name
				name.text = item.getName ();

				// add to the inventory
				IC.addToInventory (id);
			} else if (choose == 2) {
				GameObject CreatedCard = Instantiate (Card3, Positions.transform.GetChild (i).transform.position, Quaternion.identity);
				CreatedCard.transform.SetParent (CardHolder.transform);

				// Image
				SpriteRenderer renderer = CreatedCard.transform.GetChild (1).GetComponent<SpriteRenderer> ();
				// Name
				TextMesh name = CreatedCard.transform.GetChild (2).GetComponent<TextMesh> ();

				// Call rng controller for stuff
				id = RNGC.getRandom ();
				Item item = IDC.getItem (id);

				// change icon
				renderer.sprite = IDC.getSprite (id);

				// change name
				name.text = item.getName ();

				// add to the inventory
				IC.addToInventory (id);
			}
		}
	}
}
