using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CasinoGambleButton : MonoBehaviour {

	static float wait = 60f;
	float odds;
	int amount;
	InventoryController IC;
	ShopCurrency SC;

	// Use this for initialization
	void Start () {
		IC = GameObject.FindGameObjectWithTag ("InventoryController").GetComponent<InventoryController> ();
		SC = GameObject.FindGameObjectWithTag ("Currency").GetComponent<ShopCurrency> ();
		Button btn = GetComponent<Button> ();
		btn.onClick.AddListener (Gamble);
	}
	
	// Update is called once per frame
	void Update () {
		wait += Time.deltaTime;
	}

	void Gamble(){
		// check has enough currency (except amount == 1)
		if (amount != 1 && IC.getCurrency () >= amount) {
			float chance = Random.Range (0f, 1f);
			Debug.Log (chance);
			if (chance < odds) {
				Debug.Log ("win");
				IC.IncreaseCurrency (amount);
				SC.UpdateText ();
			} else {
				Debug.Log ("lose");
				IC.DecreaseCurrency (amount);
				SC.UpdateText ();
			}
		} else if (amount == 1) {
			// can only do it if wait has reached 60
			if (wait >= 60) {
				wait = 0;
			} else {
				Debug.Log ("fail timer " + wait);
				return;
			}
			float chance = Random.Range (0f, 1f);
			Debug.Log (chance);
			if (chance < odds) {
				Debug.Log ("win");
				IC.IncreaseCurrency (amount);
				SC.UpdateText ();
			} else {
				Debug.Log ("lose");
				IC.DecreaseCurrency (amount);
				SC.UpdateText ();
			}
		}
	}

	public void setOdds(float o){
		odds = o;
	}

	public void setAmount(int a){
		amount = a;
	}
}
