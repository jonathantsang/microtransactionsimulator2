using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LW_OpenButton : MonoBehaviour {

	public GameObject Disc;
	private GameObject DiscPlaces;

	private LW_OpenAnimation OA;
	private InventoryController IC;
	//private LW_SpinningCard SC;
	private LW_StateController StC;
	private LW_CreateCards CC;

	// Use this for initialization
	void Start () {
		IC = GameObject.FindGameObjectWithTag ("InventoryController").GetComponent<InventoryController> ();
		StC = GameObject.FindGameObjectWithTag ("StateController").GetComponent<LW_StateController> ();
		OA = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<LW_OpenAnimation> ();
		//SC = GameObject.FindGameObjectWithTag ("SpinningCard").GetComponent<LW_SpinningCard> ();
		CC = GameObject.FindGameObjectWithTag ("CreateCards").GetComponent<LW_CreateCards> ();
		DiscPlaces = GameObject.FindGameObjectWithTag ("Lootbox").transform.GetChild (0).gameObject;

		Button btn = GetComponent<Button> ();
		btn.onClick.AddListener (OpenCrate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OpenCrate(){
		// Change State
		StC.changeState(1);
		// create some bad discs
		int amount = IC.getHowManyToOpen();
		for(int i = 0; i < amount; i++){
			GameObject disc = Instantiate (Disc, DiscPlaces.transform.GetChild(i).position, Quaternion.identity);
			disc.GetComponent<LW_SpinningCard> ().MoveDisc ();
			Destroy (disc, 4);
		}
		// Move camera
		OA.MoveCameraForwards();
		// Make the items
		CC.MakeCards();

		// IC incremented in MakeCards
	}
}
