using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryButton : MonoBehaviour {

	private Button btn;

	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (openInventory);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void openInventory(){
		SceneManager.LoadScene ("Inventory");
	}
}
