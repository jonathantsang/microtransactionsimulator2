using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Open_Cards_Button : MonoBehaviour {

	private Button btn;

	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (openOpenCards);
	}

	// Update is called once per frame
	void Update () {

	}

	void openOpenCards(){
		SceneManager.LoadScene ("OpenCards");
	}
}
