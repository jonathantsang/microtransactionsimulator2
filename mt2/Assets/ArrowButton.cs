using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowButton : MonoBehaviour {

	public bool left;
	private Button btn;
	OpenCardsPackSpriteController OCPSC;

	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (buttonEffect);

		OCPSC = GameObject.FindGameObjectWithTag ("OpenCardsPackSpriteController").GetComponent<OpenCardsPackSpriteController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void buttonEffect () {
		if (left) {
			OCPSC.decrementPack ();
		} else {
			OCPSC.incrementPack ();
		}
	}
}
