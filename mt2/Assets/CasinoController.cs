using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasinoController : MonoBehaviour {

	GameObject panel;

	// Use this for initialization
	void Start () {
		panel = GameObject.FindGameObjectWithTag ("panel").gameObject;
		LoadButtons ();
	}

	void LoadButtons(){
		List<float> odds = new List<float> () {0.75f, 0.5f, 0.125f, 1f};
		List<int> amounts = new List<int> () {10, 100, 1000, 1};
		Debug.Log (panel.transform.childCount);
		for (int i = 0; i < panel.transform.childCount; i++) {
			panel.transform.GetChild (i).transform.GetChild (0).GetComponent<CasinoGambleButton> ().setOdds(odds[i]);
			panel.transform.GetChild (i).transform.GetChild (0).GetComponent<CasinoGambleButton> ().setAmount(amounts[i]);
		}
	}


}
