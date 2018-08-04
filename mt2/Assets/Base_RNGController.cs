using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_RNGController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int rollNumber(){

		// Skew the choosing of lower numbers over higher ones
		// pick a number from 0 to 1000
		// 0, 500, 700, 800, 880, 950, 975, 990, 995, 1000
		// 0, 30,   50,  65,  76,  86,  91,  95,  98,   99
		int value = Random.Range(0, 1000);
		int cardValue = 11;

		// Pick a number from 1 to 100
		if (value <= 500) {
			cardValue = Random.Range (0, 30);
		} else if (value <= 700) {
			cardValue = Random.Range (30, 50);
		} else if (value <= 800) {
			cardValue = Random.Range (50, 65);
		} else if (value <= 880) {
			cardValue = Random.Range (65, 76);
		} else if (value <= 950) {
			cardValue = Random.Range (76, 86);
		} else if (value <= 975) {
			cardValue = Random.Range (86, 91);
		} else if (value <= 990) {
			cardValue = Random.Range (91, 95);
		} else if (value <= 995) {
			cardValue = Random.Range (95, 98);
		} else if (value <= 1000) {
			cardValue = Random.Range (98, 99);
		}
		return cardValue;
	}
}
