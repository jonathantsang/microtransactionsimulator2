using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldsButton : MonoBehaviour {

	private Button btn;

	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (openWorldMap);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void openWorldMap(){
		
	}
}
