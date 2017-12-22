using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BF_CrateButtonClick : MonoBehaviour {

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
		btn.onClick.AddListener (CreateCrates);
		btn.onClick.AddListener (MoveCamera);
	}

	void MoveCamera(){
		// sets the state after the camera has moved
		StartCoroutine (camera.OpenCrateMovement ());
	}

	void OpenAnimation(){
		Debug.Log ("open animation");
		// open panels
		GameObject[] panels = GameObject.FindGameObjectsWithTag("panel");
		for (int i = 0; i < panels.Length; i++) {
			panels [i].GetComponent<BF_panelopen> ().OpenAnimation ();
		}
	}

	void CreateCrates(){
		// materialize the crates on the screen ui
		int OpenCount = IC.HowManyToOpen();
		for (int i = 0; i < OpenCount; i++) {
			Debug.Log ("new card");
			// call random
			int id = RNGcontroller.getRandom();
			Debug.Log (id);
			// look up id in directory of items, make the item
			Item item = IDC.getItem(id);
			string name = item.getName();
			string description = item.getDescription();
			Sprite spritetouse = IDC.getSprite (id);
				
			Transform place = CardPlaces.transform.GetChild (i).transform;
			Vector3 position = place.position;
			GameObject CardCreated = Instantiate (Card, position, Quaternion.identity);
			// Edit item image
			SpriteRenderer spriterenderer = CardCreated.transform.GetChild(1).transform.GetChild(2).GetComponent<SpriteRenderer>();
			spriterenderer.sprite = spritetouse;
			// edit the Card to have the Name
			TextMesh namemesh = CardCreated.transform.GetChild(1).transform.GetChild(3).GetComponent<TextMesh>();
			namemesh.text = name;
			// edit the description
			TextMesh descriptionmesh = CardCreated.transform.GetChild(1).transform.GetChild(4).GetComponent<TextMesh>();
			descriptionmesh.text = description;
			// change the sprite

			// parent is Cards holder
			CardCreated.transform.parent = CardHolder.transform;
		} 
	}

}
