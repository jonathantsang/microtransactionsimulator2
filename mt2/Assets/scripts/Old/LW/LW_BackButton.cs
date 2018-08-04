using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LW_BackButton : MonoBehaviour {

	private LW_OpenAnimation OA;
	//private LW_SpinningCard SC;
	private LW_StateController StC;
	private GameObject CardHolder;

	// Use this for initialization
	void Start () {
		StC = GameObject.FindGameObjectWithTag ("StateController").GetComponent<LW_StateController> ();
		OA = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<LW_OpenAnimation> ();
		//SC = GameObject.FindGameObjectWithTag ("SpinningCard").GetComponent<LW_SpinningCard> ();
		CardHolder = GameObject.FindGameObjectWithTag("CardHolder").gameObject;

		Button btn = GetComponent<Button> ();
		btn.onClick.AddListener (MoveBack);
	}

	// Update is called once per frame
	void Update () {

	}

	void MoveBack(){
		// Change State
		StC.changeState(0);

		// Move camera back
		OA.MoveCameraBackwards ();

		// delete the items
		for(int i = 0; i < CardHolder.transform.childCount; i++){
			Destroy(CardHolder.transform.GetChild(i).gameObject);
		}
	}
		
}
