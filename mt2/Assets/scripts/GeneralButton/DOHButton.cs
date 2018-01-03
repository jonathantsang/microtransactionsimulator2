﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DOHButton : MonoBehaviour {

	private Button btn;

	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (OpenDOH);
	}

	// Update is called once per frame
	void Update () {

	}

	void OpenDOH(){
		SceneManager.LoadScene ("DOH");
	}
}
