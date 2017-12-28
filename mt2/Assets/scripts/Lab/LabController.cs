using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Responsible for SETTING UP the Lab Page
public class LabController : MonoBehaviour {

	GameObject Content;
	InventoryController IC;
	ItemDirectoryController IDC;
	int rowLength = 10;

	// Use this for initialization
	void Start () {
		// Linking
		IC = GameObject.FindGameObjectWithTag("InventoryController").GetComponent<InventoryController>();
		IDC = GameObject.FindGameObjectWithTag ("ItemDirectoryController").GetComponent<ItemDirectoryController> ();
		Content = GameObject.FindGameObjectWithTag ("Content").gameObject;
		// Load
		LoadLab ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadLab(){
		// Populate the Rows of the lab inventory
		for(int i = 0; i < Content.transform.childCount; i++){
			// Go to 0 to 9 (1-10) for each inventory item
			for(int j = 0; j < rowLength; j++){
				// icon
				Image image = Content.transform.GetChild(i).transform.GetChild(j).GetComponent<Image>();
				// count (1) child is text
				Text count = Content.transform.GetChild(i).transform.GetChild(j).transform.GetChild(1).GetComponent<Text>();

				int id = i * rowLength + j;
				if (IC.checkCollected (id)) {
					// use IDC
					image.sprite = IDC.getSprite(id);
					count.text = IC.getCollectedAmount(id).ToString();
				} else {
					count.text = "";
				}
			}

		}

	}
}
