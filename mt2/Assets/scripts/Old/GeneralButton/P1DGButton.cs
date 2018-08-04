using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class P1DGButton : MonoBehaviour {

	private Button btn;

	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (OpenP1DG);
		// Disable if not unlocked from shop
		ShopUnlocked SU = GameObject.FindGameObjectWithTag("ShopUnlocked").GetComponent<ShopUnlocked>();
		// Casino upgrade is 3
		if(SU.CheckUpgrades(6) < 1){
			Destroy (transform.parent.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {

	}

	void OpenP1DG(){
		SceneManager.LoadScene ("P1DG");
	}
}
