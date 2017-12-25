using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenAllButton : MonoBehaviour {

	GameObject Cards;

	// Use this for initialization
	void Start () {
		Cards = GameObject.FindGameObjectWithTag ("CardHolder").gameObject;

		// Button
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener (OpenAllCards);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OpenAllCards(){
		if (Cards.transform.childCount < 1) {
			return;
		}
		// Go to all children of Cards
		for(int i = 0; i < Cards.transform.childCount; i++){
			// Opens card from BF_Card from card
			GameObject card = Cards.transform.GetChild (i).transform.GetChild (0).gameObject;
			if (card.activeSelf) {
				card.GetComponent<BF_Card> ().openCard ();
			}
		}
	}
}

