using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LW_BackButton : MonoBehaviour {

	private LW_OpenAnimation OA;
	private LW_SpinningCard SC;

	// Use this for initialization
	void Start () {
		OA = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<LW_OpenAnimation> ();
		SC = GameObject.FindGameObjectWithTag ("SpinningCard").GetComponent<LW_SpinningCard> ();

		Button btn = GetComponent<Button> ();
		btn.onClick.AddListener (MoveBack);
	}

	// Update is called once per frame
	void Update () {

	}

	void MoveBack(){
		// Move camera back
		OA.MoveCameraBackwards ();

		// delete the items
	}
		
}
