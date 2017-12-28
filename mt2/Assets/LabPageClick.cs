using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabPageClick : MonoBehaviour {

	LabPageSelectedController LPSC;

	// Use this for initialization
	void Start () {
		LPSC = GameObject.FindGameObjectWithTag ("SelectedController").GetComponent<LabPageSelectedController> ();

	}

}
