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
	}

	// Update is called once per frame
	void Update () {

	}

	void OpenP1DG(){
		SceneManager.LoadScene ("P1DG");
	}
}
