﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BFButton : MonoBehaviour {

	private Button btn;

	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (OpenBF);
	}

	// Update is called once per frame
	void Update () {

	}

	void OpenBF(){
		SceneManager.LoadScene ("BF");
	}
}
