using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CasinoButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Button btn = GetComponent<Button> ();
		btn.onClick.AddListener (ChangeScene);
		// Disable if not unlocked from shop
		ShopUnlocked SU = GameObject.FindGameObjectWithTag("ShopUnlocked").GetComponent<ShopUnlocked>();
		// Casino upgrade is 3
		if(SU.CheckUpgrades(3) < 1){
			Destroy (transform.parent.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ChangeScene(){
		SceneManager.LoadScene ("Casino");
	}
}
