using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LW_OpenButton : MonoBehaviour {

	private LW_OpenAnimation OA;
	private LW_SpinningCard SC;

	// Use this for initialization
	void Start () {
		OA = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<LW_OpenAnimation> ();
		SC = GameObject.FindGameObjectWithTag ("SpinningCard").GetComponent<LW_SpinningCard> ();

		Button btn = GetComponent<Button> ();
		btn.onClick.AddListener (OpenCrate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OpenCrate(){
		// Rotate camera
		OA.RotateCamera();
		// Move camera
		OA.MoveCameraForwards();
		// move cardtest disk in the lootbox
		SC.MoveDisc();
		// Make the items

		// add to the inventory

	}
}
