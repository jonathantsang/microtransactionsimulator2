using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRNGController : MonoBehaviour {

	int[] gaps = {700, 750, 800, 880, 950, 975, 990, 995, 1000};
	// no start at 0, since it finds the largest it is under
	int[] valueGaps = {30, 50, 65, 76, 86, 91, 95, 98, 99, 100 };

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
		if (value <= gaps[0]) {
			cardValue = Random.Range (0, 30);
		} else if (value <= gaps[1]) {
			cardValue = Random.Range (30, 50);
		} else if (value <= gaps[2]) {
			cardValue = Random.Range (50, 65);
		} else if (value <= gaps[3]) {
			cardValue = Random.Range (65, 76);
		} else if (value <= gaps[4]) {
			cardValue = Random.Range (76, 86);
		} else if (value <= gaps[5]) {
			cardValue = Random.Range (86, 91);
		} else if (value <= gaps[6]) {
			cardValue = Random.Range (91, 95);
		} else if (value <= gaps[7]) {
			cardValue = Random.Range (95, 98);
		} else if (value <= gaps[8]) {
			cardValue = Random.Range (98, 99);
		}
		return cardValue;
	}

	public int getColourIndexFromNumber(int v){
		int value = v;
		if (value <= valueGaps[0]) {
			return 0;
		} else if (value <= valueGaps[1]) {
			return 1;
		} else if (value <= valueGaps[2]) {
			return 2;
		} else if (value <= valueGaps[3]) {
			return 3;
		} else if (value <= valueGaps[4]) {
			return 4;
		} else if (value <= valueGaps[5]) {
			return 5;
		} else if (value <= valueGaps[6]) {
			return 6;
		} else if (value <= valueGaps[7]) {
			return 7;
		} else if (value <= valueGaps[8]) {
			return 8;
		}
		return 8;
	}
}
