using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BF_CrateButtonClick : MonoBehaviour {

	// Three listeners for the button
	static float wait1 = 5; // Wait 10 seconds before clicking again
	static float wait2 = 5;
	static float wait3 = 5;

	private BF_CameraMovement camera;
	private BF_RNGController RNGcontroller;
	private InventoryController IC;
	private ItemDirectoryController IDC;

	private GameObject CardPlaces;
	private GameObject CardHolder;
	public GameObject Card;

	// two bools for two button functions
	private bool clicked = false;

	void Start()
	{
		RNGcontroller = GameObject.FindGameObjectWithTag ("RNGController").GetComponent<BF_RNGController> ();
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<BF_CameraMovement> ();
		IC = GameObject.FindGameObjectWithTag ("InventoryController").GetComponent<InventoryController> ();
		IDC = GameObject.FindGameObjectWithTag ("ItemDirectoryController").GetComponent<ItemDirectoryController> ();

		CardPlaces = GameObject.FindGameObjectWithTag ("CardPlaces").gameObject;
		CardHolder = GameObject.FindGameObjectWithTag ("CardHolder").gameObject;

		// Button
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener (OpenAnimation);
		btn.onClick.AddListener (CreateCards);
		btn.onClick.AddListener (MoveCamera);
	}

	void MoveCamera(){
		if (wait3 < 5) {
			return;
		} else {
			wait3 = 0;
		}

		// sets the state after the camera has moved
		StartCoroutine (camera.OpenCrateMovement ());
	}

	void OpenAnimation(){
		if (wait2 < 5) {
			return;
		} else {
			wait2 = 0;
		}

		// open panels
		GameObject[] panels = GameObject.FindGameObjectsWithTag("panel");
		for (int i = 0; i < panels.Length; i++) {
			panels [i].GetComponent<BF_panelopen> ().OpenAnimation ();
		}
	}

	void CreateCards(){
		if (wait1 < 5 || CardHolder.transform.childCount != 0) {
			return;
		} else {
			wait1 = 0;
		}

		// materialize the Cards on the screen ui
		int OpenCount = IC.getHowManyToOpen();
		for (int i = 0; i < OpenCount; i++) {
			// call random
			int id = RNGcontroller.getRandom();
			// look up id in directory of items, make the item
			Item item = IDC.getItem(id);
			string name = item.getName();
			string description = item.getDescription();
			Sprite spritetouse = IDC.getSprite (id);
				
			Transform place = CardPlaces.transform.GetChild (i).transform;
			Vector3 position = place.position;
			GameObject CardCreated = Instantiate (Card, position, Quaternion.identity);

			// Access BF_Card for the card and set the item to the script
			BF_Card BFC = CardCreated.transform.GetChild(0).GetComponent<BF_Card>();
			BFC.setItem (item);

			// Edit item image
			SpriteRenderer spriterenderer = CardCreated.transform.GetChild(1).transform.GetChild(2).GetComponent<SpriteRenderer>();
			spriterenderer.sprite = spritetouse;
			// edit the Card to have the Name
			TextMesh namemesh = CardCreated.transform.GetChild(1).transform.GetChild(3).GetComponent<TextMesh>();
			namemesh.text = name;
			// edit the description
			TextMesh descriptionmesh = CardCreated.transform.GetChild(1).transform.GetChild(4).GetComponent<TextMesh>();
			descriptionmesh.text = description;

			// parent is Cards holder
			CardCreated.transform.parent = CardHolder.transform;
		} 
	}

	void Update(){
		wait1 += Time.deltaTime;
		wait2 += Time.deltaTime;
		wait3 += Time.deltaTime;
	}

}
